using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using SunnyWeatherApp.Models.Location;
using SunnyWeatherApp.Services.Abstractions;
using SunnyWeatherApp.ViewModels;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SunnyWeatherApp.Tests
{
    [TestFixture]
    public class SearchLocationListViewModelTests
    {
        private readonly Location _location = new Location
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

        private readonly Mock<ILocationSearchService> _locationSearchServiceMoc = new Mock<ILocationSearchService>();

        [SetUp]
        public void SetUpMocks()
        {
            _locationSearchServiceMoc
                .Setup(service => service.GetLocationListByTextAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<Location>
                {
                    _location
                });
        }

        [Test]
        public void LoadItemsCommand_ServiceReternLocationObject_AddReternedByServiceLocationObjectToLocationList()
        {
            //Arrange
            var searchLocationListViewModel = new SearchLocationListViewModel(_locationSearchServiceMoc.Object);

            //Act
            searchLocationListViewModel.LoadItemsCommand.Execute(null);
            var locationListResult = searchLocationListViewModel.LocationList;

            //Assert
            Assert.AreEqual(_location, locationListResult.FirstOrDefault());
        }
    }
}
