using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;

namespace SunnyWeatherApp.UITest.PageObjects
{
    public abstract class BasePage
    {
        protected WindowsDriver<WindowsElement> DriverSession;

        protected BasePage(WindowsDriver<WindowsElement> driverSession)
        {
            DriverSession = driverSession;
        }
    }
}
