using System;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models
{

    public partial class PageInteraction : BaseEfAudit
    {
        [Key]
        public long Id { get; set; }

        [StringLength(800)]
        public string InteractionDescription { get; set; }
        [StringLength(254)]
        public string Url { get; set; }
        [StringLength(400)]
        public string Interaction { get; set; }

        public long PageLoadId { get; set; }

        public virtual PageLoad PageLoad { get; set; }

    }
}