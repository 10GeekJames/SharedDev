using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace CalculatorProject.UnitTest.Factories.WebDrivers
{
    public class FirefoxWebDriver : IDisposable, ICustomWebDriver
    {
        private IWebDriver activeDriver;
        private readonly DriverOptions _linuxOptions = new FirefoxOptions();
        public FirefoxWebDriver()
        {
            _linuxOptions = new FirefoxOptions();
            ((FirefoxOptions)_linuxOptions).AddArguments("disable-gpu");
            ((FirefoxOptions)_linuxOptions).AddArguments("headless");
            ((FirefoxOptions)_linuxOptions).AddArguments("no-sandbox");
            ((FirefoxOptions)_linuxOptions).AddArguments("disable-dev-shm-usage");
        }
        public IWebDriver ActiveDriver
        {
            get
            {
                if (this.activeDriver == null)
                {
                    try
                    {
                        this.activeDriver = new FirefoxDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Drivers\executables\firefox\win"));
                    }
                    catch (System.Exception)
                    {
                        this.activeDriver = new FirefoxDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Drivers\executables\firefox\linux"), (FirefoxOptions)this._linuxOptions);
                    }

                    this.activeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                }
                return activeDriver;
            }
        }
        public void ResetBrowser()
        {
            activeDriver.Quit();
            activeDriver = null;
            try
            {
                this.activeDriver = new FirefoxDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Drivers\executables\firefox\win"));
            }
            catch (System.Exception)
            {
                this.activeDriver = new FirefoxDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Drivers\executables\firefox\linux"), (FirefoxOptions)this._linuxOptions);
            }
            this.activeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void Dispose()
        {
            if (activeDriver != null)
            {
                try {
                   activeDriver.Quit(); 
                   activeDriver.Dispose();
                } finally {                    
                    activeDriver = null;
                }
            }
        }
    }
}
