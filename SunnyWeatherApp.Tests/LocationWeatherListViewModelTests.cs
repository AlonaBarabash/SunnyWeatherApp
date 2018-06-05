using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using SunnyWeatherApp.Models.Location;
using SunnyWeatherApp.Services.Abstractions;
using SunnyWeatherApp.ApiRequestHelper;
using SunnyWeatherApp.Models;
using SunnyWeatherApp.Models.Weather;
using SunnyWeatherApp.ViewModels;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SunnyWeatherApp.Tests
{
    [TestFixture]
    public class LocationWeatherListViewModelTests
    {
        private readonly Location _locationKyiv = new Location
        {
            Key = "324505",
            LocalizedName = "Kyiv",
            Type = "City",
            AdministrativeArea = new AdministrativeArea()
            {
                LocalizedName = "",
                LocalizedType = ""
            },
            Country = new Country()
            {
                ID = "",
                LocalizedName = ""
            }
        };

        private readonly Weather _weather = new Weather
        {
            DateTime = DateTime.Now,
            IconPhrase = "Sunny",
            IsDaylight = true,
            Temperature = new Temperature
            {
                Unit = "C",
                UnitType = 17,
                Value = 20
            },
            RainProbability = 10,
            ShowProbability = 0,
            IceProbability = 0
        };


        private readonly Mock<ILocationSearchService> _locationSearchServiceMoc = new Mock<ILocationSearchService>();
        private readonly Mock<IWeatherService> _weatherServiceMoc = new Mock<IWeatherService>();
        
        [Test]
        [Order(1)]
        public void LoadItemsCommand_ServicesReternsLocationWeather_AddReternedByServicesToLocationWeatherList()
        {
            var locationWeather = new LocationWeather
            {
                Location = _locationKyiv,
                CurrentWeather = _weather
            };

            _locationSearchServiceMoc
                .Setup(service => service.GetLocationList())
                .Returns(new List<Location>
                {
                    _locationKyiv
                });

            _weatherServiceMoc
                .Setup(service => service.GetCurrentWeatherByLocationAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<Weather>
                {
                    _weather

                });


            var locationWeatherListViewModel = new LocationWeatherListViewModel(_weatherServiceMoc.Object, _locationSearchServiceMoc.Object);

            locationWeatherListViewModel.LoadItemsCommand.Execute(null);
            var locationWeatherListResult = locationWeatherListViewModel.LocationWeatherList;

            Assert.AreEqual(locationWeather.Location, locationWeatherListResult.FirstOrDefault()?.Location);
            Assert.AreEqual(locationWeather.CurrentWeather, locationWeatherListResult.FirstOrDefault()?.CurrentWeather);

        }

        [Test]
        [Order(2)]
        public void RemoveItemCommand_ServicesReternsLocationWeather_RemoveLocationWeatherList()
        {
            _locationSearchServiceMoc
                .Setup(service => service.GetLocationList())
                .Returns(null as IEnumerable<Location>);

            _locationSearchServiceMoc
                .Setup(service => service.DeleteLocationAsync(It.IsAny<string>()))
                .ReturnsAsync(true);

            _weatherServiceMoc
                .Setup(service => service.GetCurrentWeatherByLocationAsync(It.IsAny<string>()))
                .ReturnsAsync(null as IList<Weather>);
            
            var locationWeatherListViewModel = new LocationWeatherListViewModel(_weatherServiceMoc.Object, _locationSearchServiceMoc.Object);

            locationWeatherListViewModel.LoadItemsCommand.Execute(null);
            locationWeatherListViewModel.RemoveItemCommand.Execute(_locationKyiv.Key);

            var locationWeatherListResult = locationWeatherListViewModel.LocationWeatherList;

            Assert.AreEqual(null, locationWeatherListResult.FirstOrDefault());
        }
    }
}

