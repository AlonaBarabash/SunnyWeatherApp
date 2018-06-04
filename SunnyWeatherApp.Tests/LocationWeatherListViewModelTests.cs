using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using SunnyWeatherApp.Models.Location;
using SunnyWeatherApp.Services.Abstractions;
using SunnyWeatherApp.ApiRequestHelper;
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

        private readonly Location _locationLviv = new Location
        {
            Key = "324561",
            LocalizedName = "Lviv",
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
        public void LoadItemsCommand()
        {
            //Arrange
            


            //Act
            

            //Assert
            
        }
    }
}

