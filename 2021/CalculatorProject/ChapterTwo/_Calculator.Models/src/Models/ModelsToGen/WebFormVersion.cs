
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models
{
    public partial class WebFormVersion : BaseEfAudit
    {
        public WebFormVersion()
        {
            
        }
        [Key]
        public long Id { get; set; }
        [StringLength(8)]
        public string WebSafeKey { get; set; }

        public double? VersionTag { get; set; }
        [MaxLength]
        public string DataTemplateJson { get; set; }
        [MaxLength]
        public string ValuesTemplateJson { get; set; }

        public long WebFormId { get; set; }

        public virtual WebForm WebForm { get; set; }
    }
}
