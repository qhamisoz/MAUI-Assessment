﻿using Meal.UI.ViewModels;

namespace Meal.UI
{
    public partial class MainPage : ContentPage
    {
        public MainViewModel MainViewModel {  get;}

        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            BindingContext = MainViewModel = mainViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await MainViewModel.LoadCategoriesAsync();
        }
    }
}
