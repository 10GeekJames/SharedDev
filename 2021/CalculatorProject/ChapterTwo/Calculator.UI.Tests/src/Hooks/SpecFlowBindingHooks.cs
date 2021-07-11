using System;
using BoDi;
using CalculatorProject.UnitTest.Drivers;
using CalculatorProject.UnitTest.Pages;
using TechTalk.SpecFlow;
using CalculatorProject.UnitTest.Factories.WebDrivers;
using CalculatorProject.UnitTest.Factories.Environments;
using CalculatorProject.UnitTest.Wrappers;

namespace CalculatorProject.UnitTest.Hooks
{
    [Binding]
    public class SpecFlowBindingHooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriverFactory _webDriverFactory;
        private IEnvironmentUrlFactory _environmentUrlFactory;

        public SpecFlowBindingHooks(IObjectContainer objectContainer)
        {
            this._objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void SetupWebDriver()
        {
            // pass in a brower if you want other than chrome, such as edge, or firefox
            // var webDriverFactory = (IWebDriverFactory)new WebDriverFactory("edge");  *chrome, firefox, edge ~edge needs a hug if we want it
            // var _environmentUrlFactory = (IEnvironmentUrlFactory)new EnvironmentUrlFactory("prod");  *local-dev, dev, uat, prod

            _webDriverFactory = (IWebDriverFactory)new WebDriverFactory();
            _environmentUrlFactory = (IEnvironmentUrlFactory)new EnvironmentUrlFactory();
            
            this._objectContainer.RegisterInstanceAs<CalculatorAppWrapper>(new CalculatorAppWrapper());
            this._objectContainer.RegisterInstanceAs<IWebDriverFactory>(this._webDriverFactory);
            this._objectContainer.RegisterInstanceAs<IEnvironmentUrlFactory>(this._environmentUrlFactory);            
        }

        [AfterScenario]
        public void CleanupWebDriver()
        {
            if (this._webDriverFactory.Driver != null)
            {
                this._webDriverFactory.Driver.Quit();
                this._webDriverFactory.Driver.Dispose();
            }
        }
    }
}