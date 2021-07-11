using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CalculatorProject.UnitTest.Factories.WebDrivers
{
    public class ChromeWebDriver : IDisposable, ICustomWebDriver
    {
        private IWebDriver activeDriver;
        private readonly DriverOptions _linuxOptions = new ChromeOptions();
        public ChromeWebDriver()
        {
            _linuxOptions = new ChromeOptions();
            ((ChromeOptions)_linuxOptions).AddArguments("disable-gpu");
            ((ChromeOptions)_linuxOptions).AddArguments("headless");
            ((ChromeOptions)_linuxOptions).AddArguments("no-sandbox");
            ((ChromeOptions)_linuxOptions).AddArguments("disable-dev-shm-usage");
        }
        public IWebDriver ActiveDriver
        {
            get
            {
                if (this.activeDriver == null)
                {
                    try
                    {
                        this.activeDriver = new ChromeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Drivers\executables\chrome\win"));
                    }
                    catch (System.Exception)
                    {
                        this.activeDriver = new ChromeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Drivers\executables\chrome\linux"), (ChromeOptions)this._linuxOptions);
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
                this.activeDriver = new ChromeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Drivers\executables\chrome\win"));
            }
            catch (System.Exception)
            {
                this.activeDriver = new ChromeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Drivers\executables\chrome\linux"), (ChromeOptions)this._linuxOptions);
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
