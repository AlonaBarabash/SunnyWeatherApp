using System;
using System.Collections.Generic;
using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SunnyWeatherApp.Models;
using SunnyWeatherApp.ViewModels;

namespace SunnyWeatherApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationWeatherListPage : ContentPage
    {
        LocationWeatherListViewModel viewModel;

        public LocationWeatherListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = App.Container.Resolve<LocationWeatherListViewModel>();
        }

        async void AddLocation_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new SearchLocationListPage()));
        }

        void RefreshLocation_Clicked(object sender, EventArgs e)
        {
            viewModel.LoadItemsCommand.Execute(null);
        }

        void RemoveLocation_Clicked(object sender, EventArgs e)
        {
            //TODO




        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.LocationWeatherList.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}