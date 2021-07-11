using CalculatorProject.UnitTest.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace CalculatorProject.UnitTest.StepDefinitions
{
    [Binding]
    public class GooglePageDefinitionSteps : Steps
    {
        private readonly GooglePage _googlePage;
        public GooglePageDefinitionSteps(GooglePage googlePage)
        {
            this._googlePage = googlePage;
        }

        [Given(@"I navigate to the google")]
        public void INavigateToTheGoogle()
        {
            this._googlePage.NavigateTo();
        }

        [Then(@"I should be on the google")]
        public void IShouldBeOnTheGoogle()
        {
            this._googlePage.GetTitle().Should().BeEquivalentTo(this._googlePage.Title);
        }
    }
}