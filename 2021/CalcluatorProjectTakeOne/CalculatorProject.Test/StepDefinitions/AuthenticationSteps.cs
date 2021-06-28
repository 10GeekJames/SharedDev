using System.Threading;
using UITests.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace UITests.StepDefinitions
{
    [Binding]
    public class AuthenticationSteps : Steps
    {
        private readonly HeaderStructure _headerStructure;
        private readonly LoginPage _loginPage;
        private readonly HomePage _homePage;

        public AuthenticationSteps(LoginPage loginPage, HomePage homePage, HeaderStructure headerStructure, NavStructure navStructure)
        {
            this._headerStructure = headerStructure;
            this._loginPage = loginPage;
            this._homePage = homePage;
        }

        [Given(@"I perform all login activities")]
        [When(@"I perform all login activities")]
        public void ILogin()
        {
            this._homePage.NavigateTo();
            this._headerStructure.Login();
            this._loginPage.LoginWithButton("jkies@itwerx.net", "Letmein$123");
        }
    }
}

