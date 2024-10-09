using Meal.UI.ViewModels;

namespace Meal.UI.Views;

public partial class RecipeSelection : ContentPage
{
    public MealSelectionViewModel RecipeSelectionViewModel { get; }
	public RecipeSelection(MealSelectionViewModel mainViewModel)
	{
		InitializeComponent();
        BindingContext = RecipeSelectionViewModel = mainViewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        RecipeSelectionViewModel.LoadRecipeDataByCategoryNameAsync();
    }

}