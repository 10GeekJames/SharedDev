using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using CalculatorProject.UnitTest.Factories.WebDrivers;

namespace CalculatorProject.UnitTest.Drivers
{
    public class WebDriverFactory : IWebDriverFactory
    {
        private IWebDriver _webDriver;
        private string _currentBrowser = "chrome";
        public WebDriverFactory() : base()
        {

        }
        public WebDriverFactory(string defaultBrowser)
        {
            this.SetDriver(defaultBrowser);
        }
        public void SetDriver(string driverName)
        {
            driverName = driverName.ToLower();
            if (!(new List<string> { "chrome", "firefox", "edge" }.Contains(driverName)))
            {
                throw new Exception("Invalid attempt to set to unapproved driver");
            }
            this._currentBrowser = driverName;
        }
        public IWebDriver Driver
        {
            get
            {
                if (this._webDriver == null)
                {
                    switch (this._currentBrowser)
                    {
                        case "chrome":
                            this._webDriver = (new ChromeWebDriver()).ActiveDriver;
                            break;
                        case "firefox":
                            this._webDriver = (new FirefoxWebDriver()).ActiveDriver;
                            break;
                        case "edge":
                            this._webDriver = (new EdgeWebDriver()).ActiveDriver;
                            break;
                        default:
                            break;
                    }

                }
                return this._webDriver;
            }
            private set { }
        }
        public void ResetBrowser()
        {
            if (this._webDriver != null)
                ((ICustomWebDriver)this._webDriver).ResetBrowser();
        }

        public void Dispose()
        {
            this._webDriver.Dispose();
        }        
    }
}