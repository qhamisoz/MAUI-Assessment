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
    public partial class MainViewModel : BaseViewModel
    {
        private readonly IRecipeService _recipeService;
        public MainViewModel(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        ObservableCollection<Category> categories;

        [RelayCommand]
        private async void OnRefreshing()
        {
            IsRefreshing = true;

            try
            {
                await LoadCategoriesAsync();
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        public async Task LoadCategoriesAsync()
        {
            string apiUrl = "https://www.themealdb.com/api/json/v1/1/categories.php";
            Categories = new ObservableCollection<Category>(await _recipeService.GetCategoriesAsync(apiUrl));
        }

        [RelayCommand]
        private async void NavigateToRecipeSelection(Category category)
        {
            await Shell.Current.GoToAsync($"{nameof(RecipeSelection)}?Name={category.strCategory}");
        }
    }
}
