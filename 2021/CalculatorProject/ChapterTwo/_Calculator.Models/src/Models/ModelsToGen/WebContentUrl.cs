using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Calculator.Models
{
    public partial class WebContentUrl : BaseEfAudit
    {
        [Key]
        public long Id { get; set; }

        [StringLength(254)]
        public string Href { get; set; }
        [StringLength(80)]
        public string AltText { get; set; }
        [StringLength(20)]
        public string Target { get; set; }
        [StringLength(40)]
        public string Title { get; set; }
        [StringLength(250)]
        public string Description { get; set; }

        public long WebContentId { get; set; }

        public virtual WebContent WebContent { get; set; }
    }
}