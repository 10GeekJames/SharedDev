using System;
using Calculator.Models.Enums;
namespace Calculator.Models.RequestResponse
{
    public class CalculatorDoActionBehaviorRequest
    {
        public CalculatorDoActionBehavior Behavior { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }

        public bool IsReady()
        {
            try
            {
                return (this.Value1.Trim().Length > 0 && this.Value2.Trim().Length > 0);
            }
            catch (Exception) { return false; }
        }
    }
}