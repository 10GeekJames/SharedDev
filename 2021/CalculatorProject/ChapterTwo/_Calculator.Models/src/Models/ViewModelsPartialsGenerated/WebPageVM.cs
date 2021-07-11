// This file is generated, don't touch
using Calculator.Models;
using Calculator.Models.RequestResponse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models.ViewModels
{
    public partial class WebPageVM : BaseEfAudit
    {
        [Key]
        public long Id { get; set; }
        public int SortOrder { get; set; }

        [StringLength(40)]
        public string Title { get; set; }
        [StringLength(80)]
        public string SubTitle { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(180)]
        public string UrlToMatch { get; set; }
        [StringLength(30)]
        public string MenuText { get; set; }
        [StringLength(80)]
        public string Slug { get; set; }
        public long WebSiteId { get; set; }

        public virtual WebsiteVM WebsiteVM { get; set; }

        public virtual HashSet<WebContentVM> WebContentsVM { get; set; }
    }
}