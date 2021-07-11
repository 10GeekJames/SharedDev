using System;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models
{
    public partial class WebsiteAlias : BaseEfAudit
    {
        [Key]
        public long Id { get; set; }

        [StringLength(254)]
        public string Url { get; set; }
        [StringLength(254)]
        public string Subweb { get; set; }

        public long WebsiteId { get; set; }

        public virtual Website Website { get; set; }
    }
}