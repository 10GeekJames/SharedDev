using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Calculator.Models.RequestResponse;

namespace Calculator.Models
{
    public partial class ActiveBusinessData
    {
        public ActiveBusinessData()
        {
            this.LookupCategories = new HashSet<LookupCategoryViewModel>();
        }
        public long Id { get; set; }
        public bool Validated { get; set; }
        public bool Initialized { get; set; }

        public long BusinessId { get; set; }

        public virtual ICollection<LookupCategoryViewModel> LookupCategories { get; set; }

        public virtual Business Business { get; set; }
        public virtual Website WebsiteVM { get; set; }

    }
}