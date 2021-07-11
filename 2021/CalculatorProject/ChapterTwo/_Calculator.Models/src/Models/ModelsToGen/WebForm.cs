using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models
{
    public partial class WebForm : BaseEfAudit
    {
        public WebForm()
        {
            FormVersions = new HashSet<WebFormVersion>();
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

        public virtual ICollection<WebFormVersion> FormVersions { get; set; }
    }
}
