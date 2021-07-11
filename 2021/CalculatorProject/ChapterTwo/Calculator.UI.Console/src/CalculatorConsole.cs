using System;

namespace Calculator.UI.Console
{
    public class CalculatorConsole
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public int Add()
        {
            return FirstNumber + SecondNumber;
        }
        
    }
}
