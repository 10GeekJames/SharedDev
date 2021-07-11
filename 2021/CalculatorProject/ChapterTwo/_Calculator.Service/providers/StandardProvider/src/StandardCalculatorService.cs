using System;
using Calculator.Service.Interfaces;

namespace Calculator.Service
{
    public class StandardCalculatorService : ICalculatorServiceProvider
    {
        public StandardCalculatorService()
        {

        }
        public int AddIntegers(int val1, int val2)
        {
            return val1 + val2;
        }
        public int SubIntegers(int val1, int val2)
        {
            return val1 - val2;
        }
        public int AddAsIntegers(string val1, string val2)
        {
            if (!HaveValidLengths(val1, val2))
            {
                throw new FormatException("Both values are required.");
            }
            return int.Parse(val1) + int.Parse(val2);
        }
        public int SubAsIntegers(string val1, string val2)
        {
            if (!HaveValidLengths(val1, val2))
            {
                throw new FormatException("Both values are required.");
            }
            return int.Parse(val1) - int.Parse(val2);
        }
        public int MultAsIntegers(string val1, string val2)
        {
            if (!HaveValidLengths(val1, val2))
            {
                throw new FormatException("Both values are required.");
            }
            return int.Parse(val1) * int.Parse(val2);
        }
        public int DivAsIntegers(string val1, string val2)
        {
            if (!HaveValidLengths(val1, val2))
            {
                throw new FormatException("Both values are required.");
            }
            return int.Parse(val1) / int.Parse(val2);
        }

        public string AddAsStrings(string str1, string str2)
        {
            if (!HaveValidLengths(str1, str2))
            {
                throw new FormatException("Both values are required.");
            }
            return $"{str1} {str2}";
        }
        private bool HaveValidLengths(string val1, string val2)
        {
            try
            {
                return (val1.Trim().Length > 0 && val2.Trim().Length > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}