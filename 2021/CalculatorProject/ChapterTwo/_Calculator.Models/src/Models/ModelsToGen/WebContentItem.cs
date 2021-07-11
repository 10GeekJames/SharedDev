using System;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models
{
    public partial class WebContentItem : BaseEfAudit
    {
        [Key]
        public long Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float SortOrder { get; set; }
        [StringLength(40)]
        public string MiniTitle { get; set; }
        [StringLength(40)]
        public string MiniSubTitle { get; set; }
        [StringLength(140)]
        public string MiniContent { get; set; }
        [StringLength(400)]
        public string ExternalUrl { get; set; }
        [StringLength(400)]
        public string InternalUrl { get; set; }
        [StringLength(400)]
        public string VideoUrl { get; set; }
        [StringLength(400)]
        public string StreamUrl { get; set; }
        [StringLength(400)]
        public string ThumbnailUrl { get; set; }
        [StringLength(400)]
        public string BannerUrl { get; set; }
        [StringLength(240)]
        public string CommaTags { get; set; }

        [StringLength(140)]
        public string FullTitle { get; set; }
        [StringLength(400)]
        public string FullSubTitle { get; set; }
        [StringLength(80)]
        public string GoogleTrackingEventActionCode { get; set; }
        [StringLength(80)]
        public string Slug { get; set; }
        [MaxLength]
        public string FullContentJson { get; set; }

        public long WebContentItemLookupTypeId { get; set; }
        public long WebContentId { get; set; }

        [ForeignKey("WebContentItemLookupTypeId")]
        public virtual LookupType WebContentItemLookupType { get; set; }
        public virtual WebContent WebContent { get; set; }
    }
}