// This file is generated, don't touch
using Calculator.Models;
using Calculator.Models.RequestResponse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Calculator.Models.ViewModels
{
    public partial class WebContentVM : BaseEfAudit
    {
        public WebContentVM()
        {
            this.WebContentItemsVM = new HashSet<WebContentItemVM>();
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

        public virtual WebPageVM WebPageVM { get; set; }
        public virtual ICollection<WebContentItemVM> WebContentItemsVM { get; set; }
    }
}