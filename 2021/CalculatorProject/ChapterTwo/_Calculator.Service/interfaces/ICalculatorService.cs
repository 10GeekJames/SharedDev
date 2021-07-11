namespace Calculator.Service.Interfaces
{
    public interface ICalculatorService
    {
        int AddIntegers(int val1, int val2);
        int SubIntegers(int val1, int val2);
        int AddAsIntegers(string val1, string val2);
        int SubAsIntegers(string val1, string val2);
        int MultAsIntegers(string val1, string val2);
        int DivAsIntegers(string val1, string val2);
        string AddAsStrings(string str1, string str2);
    }
}