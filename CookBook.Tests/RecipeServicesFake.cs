using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;
using API.Services;

namespace CookBook.Tests
{
    public class RecipeServicesFake : IRecipeServices
    {
        private readonly List<Recipe> _recipes;

        public RecipeServicesFake()
        {
            _recipes = new List<Recipe>()
            {
                new Recipe() { Id = 1, Name = "First", Description = "test1", Date = new DateTime(2021, 04, 05, 07, 53, 23), 
                    ParentId =  null, Left = 1, Right = 16, DepthLevel = 0, TreeId = new Guid("4BC14581-22EA-4D31-A283-8EC08107B002")},
                new Recipe() { Id = 2, Name = "Second from First", Description = "test2", Date = new DateTime(2021, 04, 05, 07, 53, 23), 
                    ParentId =  1, Left = 2, Right = 9, DepthLevel = 1, TreeId = new Guid("4BC14581-22EA-4D31-A283-8EC08107B002")},
                new Recipe() { Id = 3, Name = "Third from First", Description = "test3", Date = new DateTime(2021, 04, 05, 07, 53, 23), 
                    ParentId =  1, Left = 10, Right = 13, DepthLevel = 1, TreeId = new Guid("4BC14581-22EA-4D31-A283-8EC08107B002")},
                new Recipe() { Id = 4, Name = "4-th from First", Description = "test4", Date = new DateTime(2021, 04, 05, 07, 53, 23), 
                    ParentId =  1, Left = 14, Right = 15, DepthLevel = 1, TreeId = new Guid("4BC14581-22EA-4D31-A283-8EC08107B002")},
                new Recipe() { Id = 5, Name = "5-th from Second", Description = "test5", Date = new DateTime(2021, 04, 05, 07, 53, 23), 
                    ParentId =  2, Left = 3, Right = 4, DepthLevel = 2, TreeId = new Guid("4BC14581-22EA-4D31-A283-8EC08107B002")},
                new Recipe() { Id = 6, Name = "6-th from second", Description = "test6", Date = new DateTime(2021, 04, 05, 07, 53, 23), 
                    ParentId =  2, Left = 5, Right = 8, DepthLevel = 2, TreeId = new Guid("4BC14581-22EA-4D31-A283-8EC08107B002")},
                new Recipe() { Id = 7, Name = "7-th from 6", Description = "test7", Date = new DateTime(2021, 04, 05, 07, 53, 23), 
                    ParentId =  6, Left = 6, Right = 7, DepthLevel = 3, TreeId = new Guid("4BC14581-22EA-4D31-A283-8EC08107B002")},
                new Recipe() { Id = 8, Name = "8-th from 3", Description = "test8", Date = new DateTime(2021, 04, 05, 07, 53, 23), 
                    ParentId =  3, Left = 11, Right = 12, DepthLevel = 2, TreeId = new Guid("4BC14581-22EA-4D31-A283-8EC08107B002")},
            };
        }

        public async Task<List<Recipe>> GetRecipesAsync()
        {
            return _recipes.ToList();
        }

        public async Task<Recipe> GetRecipeByIdAsync(int recipeId)
        {
            return _recipes.FirstOrDefault(x => x.Id == recipeId);
        }

        public async Task<bool> CreateRecipeAsync(Recipe recipe)
        {
            _recipes.Add(recipe);
            var checkContain = _recipes.Any(item => item.Id == recipe.Id);
            return checkContain;
        }

        public Task<bool> UpdateRecipeAsync(Recipe recipeToUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<int> FindLeftAtSpecificDeep(int deepLevel, Guid treeId, int parentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IncrementAllPositionsWhenRecipeAdded(int right, Guid treeId, int parentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Recipe>> GetAllParents(int id)
        {
            throw new NotImplementedException();
        }
    }
}