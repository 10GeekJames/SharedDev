// This file is generated, don't touch
using Calculator.Models;
using Calculator.Models.RequestResponse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Calculator.Models.ViewModels
{
    public partial class BusinessVM : BaseEfAudit
    {
        public BusinessVM()
        {
            WebsitesVM = new HashSet<WebsiteVM>();
        }

        [Key]
        public long Id { get; set; }

        [Required, StringLength(40)]
        public string Name { get; set; }
        [StringLength(200)]
        public string FileKey { get; set; }

        public long? IndividualId { get; set; }

        public virtual IndividualVM IndividualVM { get; set; }
        public virtual ICollection<WebsiteVM> WebsitesVM { get; set; }
    }
}