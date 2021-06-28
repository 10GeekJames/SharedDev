using System.Collections;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using CalculatorProject.Test.Factories.WebDrivers;

namespace CalculatorProject.Test.Pages
{
    public abstract class PagesBase
    {
        private IWebDriverFactory _webDriverFactory;
        public virtual string Url { get { return ""; } }
        public abstract string Title { get; }
        public PagesBase(IWebDriverFactory webDriverFactory)
        {
            this._webDriverFactory = webDriverFactory;

        }
        public void NavigateTo()
        {
            this._webDriverFactory.Driver.Navigate().GoToUrl(this.Url);
        }

        protected IWebElement FindElement(By element)
        {
            return this._webDriverFactory.Driver.FindElement(element);
        }
        protected ICollection<IWebElement> FindElements(By element)
        {
            return this._webDriverFactory.Driver.FindElements(element);
        }
        public string GetTitle()
        {
            return this._webDriverFactory.Driver.Title;
        }
    }
}
