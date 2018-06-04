using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SunnyWeatherApp.Models;
using SunnyWeatherApp.Views;
using SunnyWeatherApp.ViewModels;

namespace SunnyWeatherApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LocationWeatherListPage : ContentPage
	{
        ItemsViewModel viewModel;

        public LocationWeatherListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new SearchLocationListPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}