// This file is generated, don't touch
using Calculator.Models;
using Calculator.Models.RequestResponse;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
namespace Calculator.Models.ViewModels
{
    public partial class LookupTypeVM : BaseEf
    {
        [Key]
        public long Id { get; set; }
        public long? SortOrderValue { get; set; }
        public bool? TypeBool { get; set; }
        public long? TypeNumber { get; set; }
        [StringLength(200)]
        public string TypeText { get; set; }
        [StringLength(200)]
        public string TypeSpecialA { get; set; }
        [StringLength(200)]
        public string TypeSpecialB { get; set; }
        public string TypeBlob { get; set; }
        [StringLength(10)]
        public string TypeJson { get; set; }
        [StringLength(80)]
        public string LookupText { get; set; }
        [StringLength(160)]
        public string DisplayText { get; set; }
        [StringLength(400)]
        public string Value { get; set; }

        public long? ParentLookupTypeId { get; set; }
        public long? OwnerIndividualId { get; set; }
        public long BusinessId { get; set; }
        public long LookupCategoryId { get; set; }

        public virtual BusinessVM BusinessVM { get; set; }
        [ForeignKey("OwnerIndividualId")]
        public virtual IndividualVM OwnerIndividualVM { get; set; }
        public virtual LookupCategoryVM LookupCategoryVM { get; set; }
    }
}