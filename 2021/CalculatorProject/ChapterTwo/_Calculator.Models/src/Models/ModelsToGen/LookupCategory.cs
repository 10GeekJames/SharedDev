using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
namespace Calculator.Models
{
    public partial class LookupCategory : BaseEf
    {
        public LookupCategory()
        {
            LookupTypes = new HashSet<LookupType>();
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

        public virtual Business Business { get; set; }
        public virtual ICollection<LookupType> LookupTypes { get; set; }
    }
}