using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using SunnyWeatherApp.UITest.Driver;
using SunnyWeatherApp.UITest.PageObjects;

namespace SunnyWeatherApp.UITest.Tests
{
    [TestFixture]
    public class SunnyWeatherAppTest
    {
        private const string WearherAppAutomationId = "02f75403-ae66-432b-9602-d50d41f12bdf_wd704vwwbs5qe!App";

        private readonly WindowsApplicationDriver _windowsApplicationDriver = new WindowsApplicationDriver();
        protected WindowsDriver<WindowsElement> DriverInstance;

        [OneTimeSetUp]
        public void StartDriver()
        {
            _windowsApplicationDriver.StartDriver();
        }

        [SetUp]
        public void SetupSession()
        {
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", WearherAppAutomationId);
            appCapabilities.SetCapability("platformName", "Windows");

            DriverInstance = _windowsApplicationDriver.GetSessionWithRetry<WindowsElement>(appCapabilities, 10);

            DriverInstance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void QuitSession()
        {
            DriverInstance.Quit();
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            _windowsApplicationDriver.CloseDriver();
        }


        [Test]
        public void SearchLoactionByLocationNameTest()
        {
            var cityName = "Lviv";

            var locationWeatherListPage = new LocationWeatherListPage(DriverInstance);
            //Assert.IsTrue(locationWeatherListPage.IsOppened());

            var firstItem = locationWeatherListPage.ClickAddLocationButton()
                .SetValueToSearch(cityName).ClickSearchButton()
                .GetSearchResultLocationNames().First();

            Assert.AreEqual(cityName, firstItem);
        }

    }
}
