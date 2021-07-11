using FluentAssertions;
using System.Threading;
using TechTalk.SpecFlow;
using CalculatorProject.UnitTest.Wrappers;

namespace CalculatorProject.UnitTest.StepDefinitions
{
    [Binding]
    public class CalculatorStepDefinitions : Steps
    {
        private CalculatorAppWrapper _calculatorAppWrapper;
        public CalculatorStepDefinitions(CalculatorAppWrapper calculatorAppWrapper){
            _calculatorAppWrapper = calculatorAppWrapper;
        }

        [Given(@"I have a calculator")]
        public void IHaveACalculator()
        {
            this._calculatorAppWrapper.Init();
        }

        [When(@"I add (.*) plus (.*)")]
        public void IAddTwoNumbers(int firstNum, int secondNum)
        {
            this._calculatorAppWrapper.Calculator.FirstNumber = firstNum;
            this._calculatorAppWrapper.Calculator.SecondNumber = secondNum;
        }

        [Then(@"I get (.*)")]
        public void IGetAnAnswer(int answer)
        {
            this._calculatorAppWrapper.Calculator.Add().Should().Be(answer);
        }
    }
}

