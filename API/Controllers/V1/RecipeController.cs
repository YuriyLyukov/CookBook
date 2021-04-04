using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using API.Contracts.V1.Requests;
using API.Contracts.V1.Responses;
using API.Domain;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    public class RecipeController : Controller
    {
        private readonly IRecipeServices _recipeService;

        public RecipeController(IRecipeServices recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet(ApiRoutes.Recipes.GetAll)]
        public async Task<IActionResult> Getall()
        {
            return Ok(await _recipeService.GetRecipesAsync());
        }

        [HttpGet(ApiRoutes.Recipes.Get)]
        public async Task<IActionResult> Get([FromRoute] int recipeId)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(recipeId);

            if (recipe == null)
                return NotFound();
            
            return Ok(recipe);
        }

        [HttpPost(ApiRoutes.Recipes.Create)]
        public async Task<IActionResult> Create([FromBody] CreateRecipeRequest recipeRequest)
        {
            if (recipeRequest.Name == null || recipeRequest.Description == null)
            {
                return BadRequest(new {error = "Null variables [Name and Description] are not allowed"});
            }
            
            var recipe = new Recipe
            {
                Id = new int(),
                Name = recipeRequest.Name,
                Description = recipeRequest.Description,
                Date = DateTime.UtcNow,
                ParentId = recipeRequest.ParentId,
                Left = 1,
                Right = 2,
                DepthLevel = 0,
                TreeId = Guid.NewGuid()
            };
            if (recipe.ParentId != null)
            {
                var parentRecipe =  await _recipeService.GetRecipeByIdAsync((int)recipe.ParentId);
                recipe.DepthLevel = parentRecipe.DepthLevel + 1;
                recipe.TreeId = parentRecipe.TreeId;
                recipe.Left = await _recipeService.FindLeftAtSpecificDeep(recipe.DepthLevel, recipe.TreeId, (int)recipe.ParentId);
                recipe.Right = recipe.Left + 1;
                await _recipeService.IncrementAllPositionsWhenRecipeAdded(recipe.Right, recipe.TreeId, (int)recipe.ParentId);
            }
            await _recipeService.CreateRecipeAsync(recipe);
            var response = new RecipeResponse
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                Date = recipe.Date,
                ParentId = recipe.ParentId,
                DepthLevel = recipe.DepthLevel,
                TreeId = recipe.TreeId
            };
            return Ok(response);
        }

        [HttpPatch(ApiRoutes.Recipes.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateRecipeRequest recipeRequest)
        {
            if (recipeRequest.Name == null || recipeRequest.Description == null)
            {
                return BadRequest(new {error = "Null variables [Name and Description] are not allowed"});
            }

            if (await _recipeService.GetRecipeByIdAsync((int)recipeRequest.Id) == null)
            {
                return BadRequest(new {error = "Recipe not found!"});
            }

            var recipe = await _recipeService.GetRecipeByIdAsync((int)recipeRequest.Id);
            recipe.Name = recipeRequest.Name;
            recipe.Description = recipeRequest.Description;
            await _recipeService.UpdateRecipeAsync(recipe);
            return Ok(recipe);
        }

        [HttpGet(ApiRoutes.Recipes.GetAllParents)]
        public async Task<IActionResult> GetAllParents([FromRoute] int id)
        {
            var parents = await _recipeService.GetAllParents(id);
            return Ok(parents);
        }
    }
}