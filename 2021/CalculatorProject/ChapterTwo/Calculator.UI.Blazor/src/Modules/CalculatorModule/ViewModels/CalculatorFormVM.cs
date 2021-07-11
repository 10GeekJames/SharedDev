using Calculator.Models.Enums;
namespace Calculator.UI.Blazor.Shared
{
    public class CalculatorFormVM
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public int CalculatorDoActionBehaviorId { get; set; }
        public CalculatorDoActionBehavior CalculatorDoActionBehavior { get; set; }
    }
}