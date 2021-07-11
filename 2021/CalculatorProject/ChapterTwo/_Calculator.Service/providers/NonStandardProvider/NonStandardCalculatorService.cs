using System;
using Calculator.Service.Interfaces;

namespace Calculator.Service
{
    public class NonStandardCalculatorService : ICalculatorServiceProvider
    {
        public NonStandardCalculatorService()
        {

        }
        public int AddIntegers(int val1, int val2)
        {
            return 999;
        }
        public int SubIntegers(int val1, int val2)
        {
            return -999;
        }

        public int AddAsIntegers(string val1, string val2)
        {
            return int.Parse(val1) + int.Parse(val2) + 9999;
        }
        public int SubAsIntegers(string val1, string val2)
        {
            return int.Parse(val1) + int.Parse(val2) - 9999;
        }

         public int MultAsIntegers(string val1, string val2)
        {
            return int.Parse(val1) * int.Parse(val2) -999999;
        }
        public int DivAsIntegers(string val1, string val2)
        {
            return int.Parse(val1) / int.Parse(val2) + 999999;
        }
        public string AddAsStrings(string str1, string str2)
        {
            return $"{str2} {str1}";
        }
    }
}   