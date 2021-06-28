using System;
using BoDi;
using CalculatorProject.Test.Drivers;
using CalculatorProject.Test.Pages;
using TechTalk.SpecFlow;
using CalculatorProject.Test.Factories.WebDrivers;
using CalculatorProject.Test.Factories.Environments;

namespace CalculatorProject.Test.Hooks
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