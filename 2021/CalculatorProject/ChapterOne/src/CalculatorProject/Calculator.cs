using System;

namespace CalculatorProject
{
    public class Calculator
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public int Add()
        {
            return FirstNumber + SecondNumber;
        }

        public int Sub()
        {
            return FirstNumber - SecondNumber;
        }

        public string ShowMeBob() {
            return "Bob";
        }
        
    }
}
