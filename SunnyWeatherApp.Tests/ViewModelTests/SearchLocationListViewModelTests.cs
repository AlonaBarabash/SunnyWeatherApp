using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using SunnyWeatherApp.Models.Location;
using SunnyWeatherApp.Services.Abstractions;
using SunnyWeatherApp.ApiRequestHelper;
using SunnyWeatherApp.ViewModels;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SunnyWeatherApp.Tests
{
    [TestFixture]
    public class SearchLocationListViewModelTests
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

        private readonly Mock<ILocationSearchService> _locationSearchServiceMoc = new Mock<ILocationSearchService>();
        
        [Test]
        public void SearchLocationCommand_ServiceReternLocationObject_AddReternedByServiceLocationObjectToLocationList()
        {
            //Arrange
            _locationSearchServiceMoc
                .Setup(service => service.GetLocationListByTextAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<Location>
                {
                    _locationKyiv
                });
            var searchLocationListViewModel = new SearchLocationListViewModel(_locationSearchServiceMoc.Object);

            //Act
            searchLocationListViewModel.SearchLocationCommand.Execute(null);
            var locationListResult = searchLocationListViewModel.LocationList;

            //Assert
            Assert.AreEqual(_locationKyiv, locationListResult.FirstOrDefault());
        }

        [Test]
        [ExpectedException(typeof(ApiException))]
        public void SearchLocationCommand_ServiceReternException_ApiException()
        {
            //Arrange
            string textOfException = "Text of exception";
            _locationSearchServiceMoc
                .Setup(service => service.GetLocationListByTextAsync(It.IsAny<string>()))
                .ThrowsAsync(new ApiException(textOfException));

            var searchLocationListViewModel = new SearchLocationListViewModel(_locationSearchServiceMoc.Object);

            //Act
            searchLocationListViewModel.SearchLocationCommand.Execute(null);
        }

        [Test]
        public void SearchLocationCommand_ServiceReternExceptionWithStringMessage_ReternErrorMessage()
        {
            //Arrange
            string textOfException = "Text of exception";
            string space = " ";
            _locationSearchServiceMoc
                .Setup(service => service.GetLocationListByTextAsync(It.IsAny<string>()))
                .ThrowsAsync(new ApiException(textOfException));

            var searchLocationListViewModel = new SearchLocationListViewModel(_locationSearchServiceMoc.Object);

            //Act
            searchLocationListViewModel.SearchLocationCommand.Execute(null);

            //Assert
            Assert.AreEqual($"{space}{textOfException}", searchLocationListViewModel.ErrorMessage);
            Assert.IsTrue(searchLocationListViewModel.IsErrorMessageVisible);
            Assert.IsFalse(searchLocationListViewModel.IsListVisible);
        }

        [Test]
        [TestCase("message", "code")]
        [TestCase("", "code")]
        [TestCase("message", "")]
        [TestCase("", "")]
        public void SearchLocationCommand_ServiceReternExceptionWithServerErrorResponseModel_ReternErrorMessage(string message, string code)
        {
            //Arrange
            var serverErrorResponse = new ServerErrorResponseModel
            {
                Message = message,
                Code = code
            };

            string space = " ";
            _locationSearchServiceMoc
                .Setup(service => service.GetLocationListByTextAsync(It.IsAny<string>()))
                .ThrowsAsync(new ApiException(serverErrorResponse));

            var searchLocationListViewModel = new SearchLocationListViewModel(_locationSearchServiceMoc.Object);

            //Act
            searchLocationListViewModel.SearchLocationCommand.Execute(null);

            //Assert
            Assert.AreEqual($"{serverErrorResponse.Code}{space}{serverErrorResponse.Message}", searchLocationListViewModel.ErrorMessage);
            Assert.IsTrue(searchLocationListViewModel.IsErrorMessageVisible);
            Assert.IsFalse(searchLocationListViewModel.IsListVisible);
        }
        [Test]
        public void SearchLocationCommand_ServiceReternLocationList_TheCorrectNumberOfLocationsIsReternedAfterSeveralRequests()
        {
            //Arrange
            var locationList = new List<Location>
            {
                _locationKyiv,
                _locationLviv
            };
            _locationSearchServiceMoc
                .Setup(service => service.GetLocationListByTextAsync(It.IsAny<string>()))
                .ReturnsAsync(locationList);
            var searchLocationListViewModel = new SearchLocationListViewModel(_locationSearchServiceMoc.Object);

            //Act
            searchLocationListViewModel.SearchLocationCommand.Execute(null);
            var locationListResult = searchLocationListViewModel.LocationList;

            //Assert
            Assert.AreEqual(locationList.Count, locationListResult.Count);
        }
    }
}
