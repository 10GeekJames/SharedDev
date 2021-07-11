using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Calculator.Models
{
    public partial class WebContent : BaseEfAudit
    {
        public WebContent()
        {
            this.WebContentItems = new HashSet<WebContentItem>();
        }

        [Key]
        public long Id { get; set; }
        public float SortOrder { get; set; }
        [StringLength(40)]
        public string Title { get; set; }
        [StringLength(80)]
        public string SubTitle { get; set; }
        [StringLength(80)]
        public string Slug { get; set; }

        public long WebPageId { get; set; }

        public virtual WebPage WebPage { get; set; }
        public virtual ICollection<WebContentItem> WebContentItems { get; set; }
    }
}