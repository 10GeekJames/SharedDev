using System.Collections.Generic;

namespace Calculator.Models.RequestResponse
{
    public partial class LookupTypeViewModel
    {        
        public long Id { get; set; }
        public long? SortOrderValue { get; set; }
        public bool? TypeBool { get; set; }
        public long? TypeNumber { get; set; }
        public string TypeText { get; set; }
        public string TypeSpecialA { get; set; }
        public string TypeSpecialB { get; set; }
        public string TypeBlob { get; set; }
        public string TypeJson { get; set; }
        public string LookupText { get; set; }
        public string DisplayText { get; set; }
        public string Value { get; set; }
        public long? ParentLookupTypeId { get; set; }
        public long LookupCategoryId { get; set; }
        public virtual LookupCategoryViewModel LookupCategory { get; set; }
    }
}