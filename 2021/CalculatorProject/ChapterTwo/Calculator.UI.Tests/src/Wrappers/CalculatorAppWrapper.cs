using OpenQA.Selenium;
using CalculatorProject.UnitTest.Factories.WebDrivers;

using CalculatorProject;

namespace CalculatorProject.UnitTest.Wrappers
{
    public class CalculatorAppWrapper
    {
        private Calculator _calculator;
        public Calculator Calculator { get { return _calculator; } private set { } }
        public CalculatorAppWrapper()
        {
            _calculator = new Calculator();
        }
        public void Init()
        {
            _calculator = new Calculator();
        }
    }
}

