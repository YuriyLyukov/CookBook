using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class RecipeServices : IRecipeServices
    {
        private readonly DataContext _dataContext;

        public RecipeServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Recipe>> GetRecipesAsync()
        {
            return await _dataContext.Recipes.ToListAsync();
        }

        public async Task<Recipe> GetRecipeByIdAsync(int recipeId)
        {
            return await _dataContext.Recipes.SingleOrDefaultAsync(x => x.Id == recipeId);
        }

        public async Task<bool> CreateRecipeAsync(Recipe recipe)
        {
            await _dataContext.Recipes.AddAsync(recipe);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> UpdateRecipeAsync(Recipe recipeToUpdate)
        {
            _dataContext.Recipes.Update(recipeToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeletePostAsync(int recipeId)
        {
            var recipe = await GetRecipeByIdAsync(recipeId);
            if (recipe == null)
                return false;
            _dataContext.Recipes.Remove(recipe);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<int> FindLeftAtSpecificDeep(int deepLevel, Guid treeId, int parentId)
        {
            int left;
            var recipes = await _dataContext.Recipes.ToListAsync();
            var parent = recipes.Find(x => x.Id == parentId);
            var filteredRecipes = recipes.FindAll(x => x.DepthLevel == deepLevel && x.TreeId == treeId && x.Left >= parent.Left && x.Right <= parent.Right);
            if(filteredRecipes.Count == 0)
            {
                left = parent.Left + 1;
            }
            else
            {
                left = filteredRecipes.Select(x => x.Right).Max() + 1;
            }
            return left;
        }

        public async Task<bool> IncrementAllPositionsWhenRecipeAdded(int right, Guid treeId, int parentId)
        {
            var parent = await GetRecipeByIdAsync(parentId);
            var recipes =  await _dataContext.Recipes.Where(x => x.TreeId == treeId).ToListAsync();
            if (recipes.Count == 1)
            {
                parent.Right += 2;
                _dataContext.Update(parent);
            }
            else
            {
                var filteredRecipes = recipes.FindAll(x => x.Right > parent.Right).OrderBy(x => x.Right).ToList();
                if (filteredRecipes.Count == 0)
                {
                    parent.Right = right + 1;
                }
                else
                {
                    List<Recipe> ancestors = new List<Recipe>();
                    var parentIdSearch = parent.ParentId;
                    if (parentIdSearch == null)
                    {
                        ancestors.Add(filteredRecipes.Find(x => x.Id == parentIdSearch));
                    }
                    else
                    {
                        void FindAllParents(int? parentIdSearch)
                        {
                            if (parentIdSearch != null)
                            {
                                var parentSearch = filteredRecipes.First(x => x.Id == parentIdSearch);
                                ancestors.Add(parentSearch);
                                parentIdSearch = parentSearch.ParentId;
                                FindAllParents(parentIdSearch); 
                            }
                        }
                        FindAllParents(parentIdSearch);
                    }
                    List<Recipe> notancestors = filteredRecipes.Except(ancestors).ToList();
                    foreach (var item in ancestors)
                    { 
                        item.Right += 2;
                        _dataContext.Update(item);
                    }

                    foreach (var item in notancestors)
                    {
                        item.Left += 2;
                        item.Right += 2;
                        _dataContext.Update(item);
                    }

                    parent.Right += 2;
                    _dataContext.Update(parent);
                }
            }
            return true;
        }
    }
}