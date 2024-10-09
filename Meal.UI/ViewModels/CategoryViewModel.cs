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
    public partial class CategoryViewModel : BaseViewModel
    {        
        private readonly IRecipeService _recipeService;

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        string categoryName;

        public CategoryViewModel(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        
        [RelayCommand]
        private async void NavigateToRecipeSeletion(Category category)
        {
            await Shell.Current.GoToAsync($"{nameof(RecipeSelection)}?Id={category.strCategory}");
        }


    }
}
