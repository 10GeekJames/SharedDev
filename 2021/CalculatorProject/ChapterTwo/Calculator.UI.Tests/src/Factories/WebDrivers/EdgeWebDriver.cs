using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace CalculatorProject.UnitTest.Factories.WebDrivers
{
    public class EdgeWebDriver : IDisposable, ICustomWebDriver
    {
        private IWebDriver activeDriver;
        private readonly DriverOptions _linuxOptions = new EdgeOptions();
        public EdgeWebDriver()
        {
            _linuxOptions = new EdgeOptions();
            /* ((EdgeOptions)_linuxOptions).AddArguments("disable-gpu");
            ((EdgeOptions)_linuxOptions).AddArguments("headless");
            ((EdgeOptions)_linuxOptions).AddArguments("no-sandbox");
            ((EdgeOptions)_linuxOptions).AddArguments("disable-dev-shm-usage"); */
        }
        public IWebDriver ActiveDriver
        {
            get
            {
                if (this.activeDriver == null)
                {
                    try
                    {
                        this.activeDriver = new EdgeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Drivers\executables\edge\win\"));
                    }
                    catch (System.Exception)
                    {
                        this.activeDriver = new EdgeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Drivers\executables\edge\linux"), (EdgeOptions)this._linuxOptions);
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
                this.activeDriver = new EdgeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Drivers\executables\edge\win"));
            }
            catch (System.Exception)
            {
                this.activeDriver = new EdgeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Drivers\executables\edge\linux"), (EdgeOptions)this._linuxOptions);
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
