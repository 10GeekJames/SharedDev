using FluentAssertions;
using System.Threading;
using TechTalk.SpecFlow;
using CalculatorProject.UnitTest.Wrappers;
using Calculator.Service;
using Calculator.Service.Interfaces;

namespace CalculatorProject.UnitTest.StepDefinitions
{
    [Binding]
    public class CalculatorUnitStepDefinitions : Steps
    {
        private ICalculatorService _calculatorService;
        private int _answer = 0;
        public CalculatorUnitStepDefinitions(ICalculatorService calculatorService){
            _calculatorService = calculatorService;
        }

        [Given(@"I have a calculator")]
        public void IHaveACalculator()
        {
            this._calculatorService.Should().NotBeNull();
        }

        [When(@"I add (.*) plus (.*)")]
        public void IAddTwoNumbers(string firstNum, string secondNum)
        {
            this._answer = this._calculatorService.AddAsIntegers(firstNum, secondNum);
        }

        [Then(@"I get (.*)")]
        public void IGetAnAnswer(int answer)
        {
            this._answer.Should().Be(answer);
        }
    }
}

