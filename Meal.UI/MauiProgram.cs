using Meal.UI.Services;
using Meal.UI.ViewModels;
using Meal.UI.Views;
using Microsoft.Extensions.Logging;

namespace Meal.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            // resolve Http Client
            builder.Services.AddSingleton<HttpClient>();

            // Services
            builder.Services.AddSingleton<IRecipeService, RecipeService>();

            // View Models
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MealDetailViewModel>();
            builder.Services.AddSingleton<CategoryViewModel>();
            builder.Services.AddSingleton<MealSelectionViewModel>();

            // Pages
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<RecipeDetails>();
            builder.Services.AddSingleton<RecipeSelection>();

            return builder.Build();
        }
    }
}
