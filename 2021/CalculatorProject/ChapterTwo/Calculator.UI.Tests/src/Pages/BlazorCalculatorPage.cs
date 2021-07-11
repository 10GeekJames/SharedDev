using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using CalculatorProject.UnitTest.Factories.WebDrivers;

namespace CalculatorProject.UnitTest.Pages
{
    public class BlazorCalculatorPage : PagesBase
    {
        public override string Title { get { return "Blazor Calculator"; } }
        public override string Url { get { return "https://localhost:5015/Calculator/Index"; } }
        private IWebDriverFactory _webDriverFactory;
        private readonly IWebDriverFactory webDriverFactory;
        public BlazorCalculatorPage(IWebDriverFactory webDriverFactory) : base(webDriverFactory)
        {
            this._webDriverFactory = webDriverFactory;
        }

        private readonly By BEHAVIOR_LBL = OpenQA.Selenium.By.Id("behavior");
        private readonly By VALUE1_LBL = OpenQA.Selenium.By.Id("value1");
        private readonly By VALUE2_LBL = OpenQA.Selenium.By.Id("value2");
        private readonly By ANSWER_LBL = OpenQA.Selenium.By.Id("answer");
        private readonly By SUBMIT_BTN = OpenQA.Selenium.By.Id("submit-button");
        private readonly By CALC_FORM = OpenQA.Selenium.By.Id("calculator-form");

        protected SelectElement Behavior { get { return new SelectElement(FindElement(BEHAVIOR_LBL)); } private set { } }
        public string Value1 { get { return FindElement(VALUE1_LBL).Text; } set { FindElement(VALUE1_LBL).SendKeys(value); } }
        public string Value2 { get { return FindElement(VALUE2_LBL).Text; } set { FindElement(VALUE2_LBL).SendKeys(value); } }
        public string Answer { get { return FindElement(ANSWER_LBL).Text; } private set { } }
        public IWebElement Submit { get { return FindElement(SUBMIT_BTN); } private set { } }
        public IWebElement CalculatorForm { get { return FindElement(CALC_FORM); } private set { } }

        public void SetForm(string behavior, string value1, string value2)
        {
            this.Behavior.SelectByText(behavior);
            this.Value1 = value1;
            this.Value2 = value2;
            this.Submit.Click();
        }
    }
}



