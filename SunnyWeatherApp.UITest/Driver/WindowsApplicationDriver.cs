using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace SunnyWeatherApp.UITest.Driver
{
    public class WindowsApplicationDriver
    {
        public const string WindowsApplicationDriverUri = "http://127.0.0.1:4723";
        private Process _process;

        public void StartDriver()
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/c " + "\"C:\\Program Files (x86)\\Windows Application Driver\\WinAppDriver.exe\"");
            _process = Process.Start(processInfo);
        }

        public WindowsDriver<T> GetSessionWithRetry<T>(DesiredCapabilities appCapabilities, int retryCount) where T : IWebElement
        {
            WindowsDriver<T> driverInstance = null;
            for (; retryCount > 0; retryCount--)
            {
                try
                {
                    driverInstance = new WindowsDriver<T>(new Uri(WindowsApplicationDriverUri), appCapabilities, TimeSpan.FromMinutes(1));
                    break;
                }
                catch (Exception)
                {
                    Debug.WriteLine("Driver is not connected. Try again.");
                    continue;
                }
            }

            return driverInstance;
        }

        public void CloseDriver()
        {
            _process.CloseMainWindow();
        }
    }
}