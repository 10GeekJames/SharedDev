using Kendo.DynamicLinqCore;

namespace Calculator.Models
{
    public class DataSourceRequestWithSearchParam : DataSourceRequest
    {
        public string StringToSearchFor { get; set; }
    }

}