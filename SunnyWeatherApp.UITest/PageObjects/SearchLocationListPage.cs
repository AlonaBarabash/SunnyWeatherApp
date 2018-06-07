using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;

namespace SunnyWeatherApp.UITest.PageObjects
{
    public class SearchLocationListPage : BasePage
    {
        private WindowsElement LocationSearchByText => DriverSession.FindElementByAccessibilityId("LocationSearchByText");
        private WindowsElement ErrorMessageLable => DriverSession.FindElementByAccessibilityId("ErrorMessage");
        private IReadOnlyCollection<WindowsElement> ResultLocalizedName => DriverSession.FindElementsByAccessibilityId("ResultLocalizedName");
        
        public SearchLocationListPage(WindowsDriver<WindowsElement> driverSession) : base(driverSession)
        {
        }

        public SearchLocationListPage SetValueToSearch(string valueToSearch)
        {
            LocationSearchByText.SendKeys(valueToSearch);
            return this;
        }

        public SearchLocationListPage ClickSearchButton()
        {
            LocationSearchByText.Click();
            return this;
        }

        public IEnumerable<string> GetSearchResultLocationNames()
        {
            WaitFoSearchApplied();
            return ResultLocalizedName.Select(item => item.Text);
        }
        

        private void WaitFoSearchApplied()
        {
            for (int retryNumber = 0; retryNumber < 10; retryNumber++)
            {
                if (ErrorMessageLable.Text != string.Empty)
                {
                    break;
                }
                Task.Delay(1000);
            }
        }


    }
}
