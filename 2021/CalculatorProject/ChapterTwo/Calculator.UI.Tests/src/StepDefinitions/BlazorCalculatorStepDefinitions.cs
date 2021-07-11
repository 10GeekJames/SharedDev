using FluentAssertions;
using System.Threading;
using TechTalk.SpecFlow;
using CalculatorProject.UnitTest.Wrappers;
using CalculatorProject.UnitTest.Pages;
namespace CalculatorProject.UnitTest.StepDefinitions
{
    [Binding]
    public class BlazorCalculatorStepDefinitions : Steps
    {
        private readonly BlazorCalculatorPage _blazorCalculatorPage;
        
        public BlazorCalculatorStepDefinitions(BlazorCalculatorPage blazorCalculatorPage){
            _blazorCalculatorPage = blazorCalculatorPage;
        }

        [Given(@"I am on the blazor calculator page")]
        public void IAmOnTheBlazorCalculatorPage()
        {
            _blazorCalculatorPage.NavigateTo();
        }

        [When(@"I submit the calculator form using (.*), (.*), (.*)")]
        public void ISubmitTheFormUsing(string behavior, string firstNum, string secondNum)
        {
            _blazorCalculatorPage.SetForm(behavior, firstNum, secondNum);
        }

        [Then(@"I see (.*)")]
        public void ISeeAnAnswer(int answer)
        {
            this._blazorCalculatorPage.Answer.Should().Be(answer.ToString());
        }
    }
}

