using OpenQA.Selenium;
using CalculatorProject.Test.Factories.WebDrivers;

namespace CalculatorProject.Test.Pages
{
    public class HeaderStructure : PagesBase
    {
        public override string Title { get { return ""; } }
        private IWebDriverFactory _webDriverFactory;
        private readonly IWebDriverFactory webDriverFactory;
        public HeaderStructure(IWebDriverFactory webDriverFactory) : base(webDriverFactory)
        {
            this._webDriverFactory = webDriverFactory;
        }

        private readonly By LOGIN_OUT = OpenQA.Selenium.By.Id("login-out");
        private readonly By LOGO_PRIMARY = OpenQA.Selenium.By.Id("logo-primary");

        protected IWebElement LogInOut() { return FindElement(LOGIN_OUT); }
        protected IWebElement LogoPrimary() { return FindElement(LOGO_PRIMARY); }

        public bool IsLoggedIn(){
            return this.LogInOut().Text != "Login";
        }
        public void Login()
        {
            this.LogInOut().Click();
        }
        public void Logout()
        {
            this.LogInOut().Click();
        }
    }
}

