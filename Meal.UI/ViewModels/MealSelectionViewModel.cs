using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Meal.UI.Models;
using Meal.UI.Services;
using Meal.UI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal.UI.ViewModels
{
    [QueryProperty(nameof(Name), "Name")]
    public partial class MealSelectionViewModel : BaseViewModel
    {
        private readonly IRecipeService _recipeService;

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        ObservableCollection<Recipe> recipes;
        public MealSelectionViewModel(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [RelayCommand]
        private async void OnRefreshing()
        {
            IsRefreshing = true;

            try
            {
                await LoadRecipeDataByCategoryNameAsync();
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        public async Task LoadRecipeDataByCategoryNameAsync()
        {
            string apiUrl = $"https://www.themealdb.com/api/json/v1/1/filter.php?c={name}";
            Recipes = new ObservableCollection<Recipe>(await _recipeService.GetRecipesAsync(apiUrl));
        }

        [RelayCommand]
        private async void NavigateToRecipeDetails(Recipe recipe)
        {
            await Shell.Current.GoToAsync($"{nameof(RecipeDetails)}?Id={recipe.idMeal}");
        }

        [RelayCommand]
        async Task GoBackMain()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
