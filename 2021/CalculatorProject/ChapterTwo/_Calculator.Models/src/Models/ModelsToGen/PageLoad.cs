using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models
{
    public partial class PageLoad : BaseEfAudit
    {
        public PageLoad()
        {
            PageInteractions = new HashSet<PageInteraction>();
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
        public virtual Individual Individual { get; set; }
        
        public long BusinessId { get; set; }
        public virtual Business Business { get; set; }

        public long WebsiteId { get; set; }
        public virtual Website Website { get; set; }

        public virtual ICollection<PageInteraction> PageInteractions { get; set; }
    }
}