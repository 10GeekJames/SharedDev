using OpenQA.Selenium;
using CalculatorProject.Test.Factories.WebDrivers;

namespace CalculatorProject.Test.Pages
{
    public class GooglePage : PagesBase
    {
        public override string Title { get { return "Google"; } }
        public override string Url { get { return "https://google.com"; } }
        private IWebDriverFactory _webDriverFactory;
        private readonly IWebDriverFactory webDriverFactory;
        public GooglePage(IWebDriverFactory webDriverFactory) : base(webDriverFactory)
        {
            this._webDriverFactory = webDriverFactory;
        }

        private readonly By SEARCH_BOX = OpenQA.Selenium.By.Name("q");

        protected IWebElement GoogleSearchBox() { return FindElement(SEARCH_BOX); }
    }
}

