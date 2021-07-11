// This file is generated, don't touch
using Calculator.Models;
using Calculator.Models.RequestResponse;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
namespace Calculator.Models.ViewModels
{
    public partial class LookupCategoryVM : BaseEf
    {
        public LookupCategoryVM()
        {
            LookupTypesVM = new HashSet<LookupTypeVM>();
        }

        [Key]
        public long Id { get; set; }

        [StringLength(80)]
        public string LookupText { get; set; }
        [StringLength(160)]
        public string DisplayText { get; set; }
        [StringLength(200)]
        public long? SortOrderValue { get; set; }

        public long BusinessId { get; set; }
        public long? ParentLookupCategoryId { get; set; }

        public virtual BusinessVM BusinessVM { get; set; }
        public virtual ICollection<LookupTypeVM> LookupTypesVM { get; set; }
    }
}