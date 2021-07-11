using Kendo.DynamicLinqCore;

namespace Calculator.Models
{
    public class DataSourceRequestWithId : DataSourceRequest
    {
        public int SelectedId { get; set; }
    }

}