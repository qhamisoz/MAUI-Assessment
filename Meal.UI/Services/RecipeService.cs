using Meal.UI.Helper;
using Meal.UI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace Meal.UI.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly HttpClient _httpClient;

        public RecipeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(string apiUrl)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<CategoryRoot>(responseContent).Categories;
                }
                else
                {
                    // Handle errors - TODO:- write logger i.e. Log4Net
                    Console.WriteLine($"API request failed on GetCategoriesAsync with status code {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fatal error occured on GetCategoriesAsync method execution error message: {ex.Message}");
            }

            return null;
        }

        public async Task<IEnumerable<Recipe>> GetRecipesAsync(string apiUrl)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<Root>(responseContent).Meals;
                }
                else
                {
                    // Handle errors - TODO:- write logger i.e. Log4Net
                    Console.WriteLine($"API request failed on GetRecipes with status code {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fatal error occured on GetRecipes method execution error message: {ex.Message}");
            }

            return null;
        }        

        public async Task<RecipeDetail> GetRecipeByIdAsync(string apiUrl)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<RecipeDetailRoot>(responseContent).Meals.FirstOrDefault();
                }
                else
                {
                    // Handle errors - TODO:- write logger i.e. Log4Net
                    Console.WriteLine($"API request failed on GetRecipeById with status code {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fatal error occured on GetRecipeById method execution error message: {ex.Message}");
            }

            return null;
        }        
    }
}
