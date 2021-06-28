using UITests.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace UITests.StepDefinitions
{
    public class HeaderStructurePageSteps : Steps
    {
        private readonly HeaderStructure _headerStructure;
        public HeaderStructurePageSteps(HeaderStructure headerStructure)
        {
            this._headerStructure = headerStructure;
        }

        [Given(@"I click to login")]
        [When(@"I click to login")]
        public void IClickToLogin()
        {
            this._headerStructure.Login();
        }

        [Given(@"I am logged in")]        
        [When(@"I am logged in")]
        public void IAmLoggedIn()
        {
            this._headerStructure.IsLoggedIn().Should().BeTrue();
        }
        
        [Then(@"I should be logged in")]
        public void IShouldBeLoggedIn()
        {
            this._headerStructure.IsLoggedIn().Should().BeTrue();
        }
    }
}