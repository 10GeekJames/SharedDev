// This file is generated, don't touch
using Calculator.Models;
using Calculator.Models.RequestResponse;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models.ViewModels
{
    public partial class ActiveBusinessDataVM {
        public ActiveBusinessDataVM()
        {
            this.LookupCategoriesVM = new HashSet<LookupCategoryViewModel>();
        }
        public long Id { get; set; }
        public bool Validated { get; set; }
        public bool Initialized { get; set; }

        public long BusinessId { get; set; }

        public virtual ICollection<LookupCategoryViewModel> LookupCategoriesVM { get; set; }

        public virtual BusinessVM BusinessVM { get; set; }
        public virtual WebsiteVM WebsiteVM { get; set; }

    }
}