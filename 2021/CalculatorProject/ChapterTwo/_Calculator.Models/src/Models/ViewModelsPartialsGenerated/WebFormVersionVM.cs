// This file is generated, don't touch
using Calculator.Models;
using Calculator.Models.RequestResponse;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models.ViewModels
{
    public partial class WebFormVersionVM : BaseEfAudit
    {
        public WebFormVersionVM()
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

        public virtual WebFormVM WebFormVM { get; set; }
    }
}
