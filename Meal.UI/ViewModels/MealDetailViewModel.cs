using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Meal.UI.Models;
using Meal.UI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal.UI.ViewModels
{
    [QueryProperty(nameof(Id), "Id")]
    public partial class MealDetailViewModel : BaseViewModel
    {
        private readonly IRecipeService _recipeService;

        [ObservableProperty]
        int id;

        [ObservableProperty]
        RecipeDetail mealDetail;

        public MealDetailViewModel(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task LoadRecipeDataByIdAsync()
        {
            string apiUrl = $"https://www.themealdb.com/api/json/v1/1/lookup.php?i={id}";
            MealDetail = await _recipeService.GetRecipeByIdAsync(apiUrl);
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync(".."); 
        }
    }
}
