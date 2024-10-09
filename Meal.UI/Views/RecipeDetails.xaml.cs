using Meal.UI.ViewModels;

namespace Meal.UI.Views;

public partial class RecipeDetails : ContentPage
{
    public MealDetailViewModel MealDetailViewModel { get; }
    public RecipeDetails(MealDetailViewModel mealDetailViewModel)
    {
        InitializeComponent();
        BindingContext = MealDetailViewModel = mealDetailViewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        MealDetailViewModel.LoadRecipeDataByIdAsync();
    }
}