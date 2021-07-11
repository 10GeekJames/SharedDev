using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Calculator.Models
{
    public partial class Website : BaseEfAudit
    {
        public Website()
        {
            WebsiteAliases = new HashSet<WebsiteAlias>();
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

        public virtual Business Business { get; set; }
        public virtual Individual Individual { get; set; }

        public virtual ICollection<WebsiteAlias> WebsiteAliases { get; set; }
        public virtual ICollection<WebPage> WebPages { get; set; }

    }
}