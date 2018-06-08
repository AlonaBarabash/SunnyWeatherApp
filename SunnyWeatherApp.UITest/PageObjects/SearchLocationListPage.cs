using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SunnyWeatherApp.UITest.PageObjects
{
    public class SearchLocationListPage : BasePage
    {
        private WindowsElement RootElement => DriverSession.FindElementByAccessibilityId("RootElement");
        private WindowsElement LocationSearchByText => DriverSession.FindElementByAccessibilityId("QueryButton");
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
        public bool IsOppened()
        {
            return RootElement.Displayed;
        }
        public SearchLocationListPage ClickSearchButton()
        {
            LocationSearchByText.Click();
            return this;
        }

        public IEnumerable<string> GetSearchResultLocationNames()
        {
            Thread.Sleep(3000);
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
