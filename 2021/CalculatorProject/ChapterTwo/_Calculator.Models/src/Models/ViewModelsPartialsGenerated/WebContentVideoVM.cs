// This file is generated, don't touch
using Calculator.Models;
using Calculator.Models.RequestResponse;
using System;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models.ViewModels
{
    public partial class WebContentVideoVM : BaseEfAudit
    {
        [Key]
        public long Id { get; set; }

        [StringLength(40)]
        public string Title { get; set; }

        [StringLength(80)]
        public string SubTitle { get; set; }
        [StringLength(1000)]
        public string Body { get; set; }
        [StringLength(400)]
        public string ImageUrl { get; set; }
        [StringLength(400)]
        public string VideoUrl { get; set; }
        public DateTime PublishOn { get; set; }

        public long WebContentId { get; set; }

        public virtual WebContentVM WebContentVM { get; set; }
    }
}