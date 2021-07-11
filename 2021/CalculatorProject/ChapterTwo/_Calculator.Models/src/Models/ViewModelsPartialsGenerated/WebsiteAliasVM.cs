// This file is generated, don't touch
using Calculator.Models;
using Calculator.Models.RequestResponse;
using System;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models.ViewModels
{
    public partial class WebsiteAliasVM : BaseEfAudit
    {
        [Key]
        public long Id { get; set; }

        [StringLength(254)]
        public string Url { get; set; }
        [StringLength(254)]
        public string Subweb { get; set; }

        public long WebsiteId { get; set; }

        public virtual WebsiteVM WebsiteVM { get; set; }
    }
}