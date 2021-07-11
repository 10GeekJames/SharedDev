/* using System;
using Xunit;
using Calculator.Service.Interfaces;
using Calculator.Service;
using FluentAssertions;

namespace Calculator.UI.Console.UnitTests
{
    public class Calculator_CanDoBasicMath
    {
        private ICalculatorServiceProvider _calculatorServiceProvider;
        private ICalculatorService _calculatorService;

        public Calculator_CanDoBasicMath()
        {
            // this._calculatorServiceProvider = new NonStandardCalculatorService();
            this._calculatorServiceProvider = new StandardCalculatorService();
            this._calculatorService = new CalculatorService(_calculatorServiceProvider);
        }

        [Theory]
        [InlineData(3, 6, 9)]
        [InlineData(5, 10, 15)]
        [InlineData(6, 6, 12)]
        public void CalculatorCanAddTwoIntegers(int val1, int val2, int result)
        {
            this._calculatorService.AddIntegers(val1, val2).Should().Be(result);
        }

        [Theory]
        [InlineData(3, 6, -3)]
        [InlineData(5, 10, -5)]
        [InlineData(6, 6, 0)]
        public void CalculatorCanSubTwoIntegers(int val1, int val2, int result)
        {
            this._calculatorService.SubIntegers(val1, val2).Should().Be(result);
        }

        [Theory]
        [InlineData("Bob", "Nancy", "Bob Nancy")]
        [InlineData(@"JKL@J#LK$J@KL#$J", @"kllk1jkl123123hk;#%", @"JKL@J#LK$J@KL#$J kllk1jkl123123hk;#%")]
        public void CalculatorCanAddTwoStrings(string str1, string str2, string result)
        {
            this._calculatorService.AddAsStrings(str1, str2).Should().Be(result);
        }
    }
}

 */