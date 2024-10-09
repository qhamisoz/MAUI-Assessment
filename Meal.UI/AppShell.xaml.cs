using Meal.UI.Views;

namespace Meal.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RecipeSelection), typeof(RecipeSelection));
            Routing.RegisterRoute(nameof(RecipeDetails), typeof(RecipeDetails));
        }
    }
}
