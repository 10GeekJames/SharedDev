using OpenQA.Selenium;

namespace CalculatorProject.UnitTest.Factories.WebDrivers
{
    public interface IWebDriverFactory
    {
        void Dispose();
        IWebDriver Driver { get; } 
        void ResetBrowser();
    }
}