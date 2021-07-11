// This file is generated, don't touch
using Calculator.Models;
using Calculator.Models.RequestResponse;
using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models.ViewModels
{
    public partial class WebFormVM : BaseEfAudit
    {
        public WebFormVM()
        {
            FormVersions = new HashSet<WebFormVersionVM>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(8)]
        public string WebSafeKey { get; set; }


        [StringLength(40)]
        public string Name { get; set; }
        [StringLength(400)]
        public string Description { get; set; }
        [MaxLength]
        public string Instructions { get; set; }

        public virtual ICollection<WebFormVersionVM> FormVersions { get; set; }
    }
}
