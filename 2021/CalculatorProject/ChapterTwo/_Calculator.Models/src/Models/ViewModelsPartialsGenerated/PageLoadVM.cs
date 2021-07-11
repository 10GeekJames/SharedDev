// This file is generated, don't touch
using Calculator.Models;
using Calculator.Models.RequestResponse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models.ViewModels
{
    public partial class PageLoadVM : BaseEfAudit
    {
        public PageLoadVM()
        {
            PageInteractionsVM = new HashSet<PageInteractionVM>();
        }

        [Key]
        public long Id { get; set; }
        public DateTime? RequestDate { get; set; }

        [StringLength(450)]
        public string TargetRoute { get; set; }
        [StringLength(100)]
        public string TargetTitle { get; set; }
        [StringLength(20)]
        public string TargetId { get; set; }
        public long LoadTimeInMS { get; set; }

        public long IndividualId { get; set; }
        public virtual IndividualVM IndividualVM { get; set; }
        
        public long BusinessId { get; set; }
        public virtual BusinessVM BusinessVM { get; set; }

        public long WebsiteId { get; set; }
        public virtual WebsiteVM WebsiteVM { get; set; }

        public virtual ICollection<PageInteractionVM> PageInteractionsVM { get; set; }
    }
}