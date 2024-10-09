using Meal.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal.UI.Services
{
    public interface IRecipeService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync(string apiUrl); 
        Task<IEnumerable<Recipe>> GetRecipesAsync(string apiUrl);
        Task<RecipeDetail> GetRecipeByIdAsync(string apiUrl);
    }
}
