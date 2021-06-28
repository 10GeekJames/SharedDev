using OpenQA.Selenium;

namespace CalculatorProject.Test.Factories.WebDrivers
{
    public interface IWebDriverFactory
    {
        void Dispose();
        IWebDriver Driver { get; } 
        void ResetBrowser();
    }
}