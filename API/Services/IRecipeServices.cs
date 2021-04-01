using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain;

namespace API.Services
{
    public interface IRecipeServices
    {
        Task<List<Recipe>> GetRecipesAsync();
        Task<Recipe> GetRecipeByIdAsync(int recipeId);
        Task<bool> CreateRecipeAsync(Recipe recipe);
        Task<bool> UpdateRecipeAsync(Recipe recipeToUpdate);
        Task<bool> DeletePostAsync(int recipeId);
        Task<int> FindLeftAtSpecificDeep(int deepLevel, Guid treeId, int parentId);
        Task<bool> IncrementAllPositionsWhenRecipeAdded(int right, Guid treeId, int parentId);
    }
}