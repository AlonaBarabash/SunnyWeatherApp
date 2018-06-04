using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

using SunnyWeatherApp.Models;
using SunnyWeatherApp.Models.Location;
using SunnyWeatherApp.Services.Abstractions;
using SunnyWeatherApp.Views;

namespace SunnyWeatherApp.ViewModels
{
    public class LocationWeatherListViewModel : BaseViewModel
    {
        private readonly ILocationSearchService _locationSearchServiceService;
        private readonly IWeatherService _weatherService;

        public LocationWeatherListViewModel(IWeatherService weatherService, ILocationSearchService locationSearchServiceService)
        {
            _weatherService = weatherService;
            _locationSearchServiceService = locationSearchServiceService;
            Title = "Browse weather";
            LocationWeatherList = new ObservableCollection<LocationWeather>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<SearchLocationListPage, Location>(this, "AddItem", async (obj, item) =>
            {


            });
        }

        public Command LoadItemsCommand { get; set; }
        public ObservableCollection<LocationWeather> LocationWeatherList { get; set; }
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                LocationWeatherList.Clear();
                var locationList = await _locationSearchServiceService.GetItemListAsync(true);
                foreach (var location in locationList)
                {
                    var weatherList = await _weatherService.GetCurrentWeatherByLocationAsync(location.Key);
                    var locationWeather = new LocationWeather
                    {
                        Location = location,
                        CurrentWeather = weatherList.FirstOrDefault()
                    };

                    LocationWeatherList.Add(locationWeather);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}