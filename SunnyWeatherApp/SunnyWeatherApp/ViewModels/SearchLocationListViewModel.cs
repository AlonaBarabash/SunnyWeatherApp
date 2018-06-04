using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using SunnyWeatherApp.Models;
using SunnyWeatherApp.Models.Location;
using SunnyWeatherApp.Services.Abstractions;
using Xamarin.Forms;

namespace SunnyWeatherApp.ViewModels
{
    public class SearchLocationListViewModel : BaseViewModel
    {
        private readonly ILocationSearchService _locationSearchServiceService;
        private string _searchedText;

        public SearchLocationListViewModel(ILocationSearchService locationSearchService)
        {
            _locationSearchServiceService = locationSearchService;
            Title = "Browse";
            LocationList = new ObservableCollection<Location>();
            LoadItemsCommand = new Command(async () => await ExecuteSearchLocationListCommandAsync());
        }

        public ObservableCollection<Location> LocationList { get; set; }
        public Command LoadItemsCommand { get; set; }

        public string SearchedText
        {
            get => _searchedText;
            set => SetProperty(ref _searchedText, value);
        }
        private async Task ExecuteSearchLocationListCommandAsync()
        {
            await ExecuteCommandAsync(async () =>
            {
                LocationList.Clear();
                var locationList = await _locationSearchServiceService.GetLocationListByTextAsync(SearchedText);
                foreach (var location in locationList)
                {
                    LocationList.Add(location);
                }

                ErrorMessage = string.Empty;
                IsErrorMessageVisible = false;
                IsListVisible = true;
            });
        }
    }
}


