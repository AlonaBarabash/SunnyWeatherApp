using System;
using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SunnyWeatherApp.Models.Location;
using SunnyWeatherApp.ViewModels;

namespace SunnyWeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchLocationListPage : ContentPage
    {
        private SearchLocationListViewModel _viewModel;

        public SearchLocationListPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = App.Container.Resolve<SearchLocationListViewModel>();
        }
        async void OnItemSelected_AddItem(object sender, SelectedItemChangedEventArgs args)
        {
            var location = args.SelectedItem as Location;
            if (location == null)
                return;

            MessagingCenter.Send(this, "AddItem", location);
            await Navigation.PopModalAsync();
        }
        async void ReturnItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LocationSearchByText.Focus();
        }

    }
}