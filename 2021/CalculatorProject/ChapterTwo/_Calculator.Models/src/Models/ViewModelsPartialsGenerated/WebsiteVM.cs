// This file is generated, don't touch
using Calculator.Models;
using Calculator.Models.RequestResponse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Calculator.Models.ViewModels
{
    public partial class WebsiteVM : BaseEfAudit
    {
        public WebsiteVM()
        {
            WebsiteAliasesVM = new HashSet<WebsiteAliasVM>();
        }

        [Key]
        public long Id { get; set; }

        [StringLength(80)]
        public string Name { get; set; }
        [StringLength(254)]
        public string DefaultUrl { get; set; }
        [StringLength(254)]
        public string DefaultSubweb { get; set; }
        [StringLength(254)]
        public string WebsiteLogoUrl { get; set; }
        [StringLength(254)]
        public string WebsiteBannerUrl { get; set; }
        [StringLength(254)]
        public string LoadingScreenImageUrl { get; set; }
        [StringLength(40)]
        public string WebsiteTitle { get; set; }
        [StringLength(80)]
        public string WebsiteKeywords { get; set; }
        [StringLength(180)]
        public string WebsiteDescription { get; set; }

        [StringLength(30)]
        public string GoogleAnalyticsTrackingCode { get; set; }

        public long? MailgunIntegrationId { get; set; }
        public long? PrimaryIndividualId { get; set; }
        public long BusinessId { get; set; }

        public virtual BusinessVM BusinessVM { get; set; }
        public virtual IndividualVM IndividualVM { get; set; }

        public virtual ICollection<WebsiteAliasVM> WebsiteAliasesVM { get; set; }
        public virtual ICollection<WebPageVM> WebPagesVM { get; set; }

    }
}