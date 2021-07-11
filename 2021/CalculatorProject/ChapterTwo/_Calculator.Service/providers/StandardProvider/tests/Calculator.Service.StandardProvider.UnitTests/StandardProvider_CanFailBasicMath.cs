using System;
using Xunit;
using Calculator.Service.Interfaces;
using Calculator.Service;
using FluentAssertions;

namespace Calculator.Service.StandardProvider.UnitTests
{
    public class Calculator_CanFailFailBasicMath
    {
        private ICalculatorServiceProvider _calculatorServiceProvider;
        private ICalculatorService _calculatorService;

        public Calculator_CanFailFailBasicMath()
        {
            // this._calculatorServiceProvider = new NonStandardCalculatorService();
            this._calculatorServiceProvider = new StandardCalculatorService();
            this._calculatorService = new CalculatorService(_calculatorServiceProvider);
        }

        [Theory]
        [InlineData("3", "a", 99)]
        public void CalculatorCanFailFormatAddTwoIntegers(string val1, string val2, int result)
        {
            Action mathOperation = () => this._calculatorService.AddAsIntegers(val1, val2);
            mathOperation.Should().Throw<FormatException>();
        }
        [Theory]
        [InlineData("4147483647", "4147483647", int.MaxValue)]
        public void CalculatorCanFailRangeAddTwoIntegers(string val1, string val2, int result)
        {
            Action mathOperation = () => this._calculatorService.AddAsIntegers(val1, val2);
            mathOperation.Should().Throw<OverflowException>();
        }


        [Theory]
        [InlineData("Bob", "Nancy", "Bob Nancy")]
        [InlineData(@"JKL@J#LK$J@KL#$J", @"kllk1jkl123123hk;#%", @"JKL@J#LK$J@KL#$J kllk1jkl123123hk;#%")]
        public void CalculatorCanFailAddTwoStrings(string str1, string str2, string result)
        {
            this._calculatorService.AddAsStrings(str1, str2).Should().Be(result);
        }
    }
}

