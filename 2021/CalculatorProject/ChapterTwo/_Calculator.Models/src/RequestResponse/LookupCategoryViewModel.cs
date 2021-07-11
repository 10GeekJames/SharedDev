using System.Collections.Generic;

namespace Calculator.Models.RequestResponse
{
    public partial class LookupCategoryViewModel
    {
        public long Id { get; set; }
        public string LookupText { get; set; }
        public string DisplayText { get; set; }
        public long? SortOrderValue { get; set; }
        public long? ParentLookupCategoryId { get; set; }
        public ICollection<LookupTypeViewModel> LookupTypes { get; set; }
    }
}