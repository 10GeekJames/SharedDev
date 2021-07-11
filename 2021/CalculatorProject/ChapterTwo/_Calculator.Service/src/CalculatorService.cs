using Calculator.Service.Interfaces;

namespace Calculator.Service
{
    public class CalculatorService : ICalculatorService
    {
        ICalculatorServiceProvider _calculatorService;
        public CalculatorService(ICalculatorServiceProvider calculatorServiceProvider)
        {
            this._calculatorService = calculatorServiceProvider;
        }
        public int AddIntegers(int val1, int val2)
        {
            return this._calculatorService.AddIntegers(val1, val2);
        }
        public int SubIntegers(int val1, int val2)
        {
            return this._calculatorService.SubIntegers(val1, val2);
        }
        public int AddAsIntegers(string val1, string val2)
        {
            return this._calculatorService.AddAsIntegers(val1, val2);
        }
        public int SubAsIntegers(string val1, string val2)
        {
            return this._calculatorService.SubAsIntegers(val1, val2);
        }
        public int MultAsIntegers(string val1, string val2)
        {
            return this._calculatorService.MultAsIntegers(val1, val2);
        }
        public int DivAsIntegers(string val1, string val2)
        {
            return this._calculatorService.DivAsIntegers(val1, val2);
        }        

        
        
        public string AddAsStrings(string str1, string str2)
        {
            return this._calculatorService.AddAsStrings(str1, str2);
        }        
    }
}