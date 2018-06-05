using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;

namespace SunnyWeatherApp.UITest.PageObjects
{
    public class LocationWeatherListPage : BasePage
    {
        private WindowsElement RootElement => DriverSession.FindElementByAccessibilityId("RootElement");
        private WindowsElement AddLocation => DriverSession.FindElementByAccessibilityId("AddButton");
        private IReadOnlyCollection<WindowsElement> LocationsNames => DriverSession.FindElementsByAccessibilityId("LocalizedName");

        public LocationWeatherListPage(WindowsDriver<WindowsElement> driverSession) : base(driverSession)
        {
        }

        public bool IsOppened()
        {
            return RootElement.Displayed;
        }

        public SearchLocationListPage ClickAddLocationButton()
        {
            AddLocation.Click();
            return new SearchLocationListPage(DriverSession);
        }

        public IEnumerable<string> GetLocationsList()
        {
            return LocationsNames.Select(item => item.Text);
        }

        public LocationWeatherListPage WaitForValueAddedInList(string value, int attemptsCount)
        {
            for (; attemptsCount > 0; attemptsCount--)
            {
                if (LocationsNames.Any(item => item.Text.Equals(value))) break;
                Task.Delay(500);
            }
            return this;
        }

    }
}
