using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Calculator.Models
{
    public partial class Business : BaseEfAudit
    {
        public Business()
        {
            Websites = new HashSet<Website>();
        }

        [Key]
        public long Id { get; set; }

        [Required, StringLength(40)]
        public string Name { get; set; }
        [StringLength(200)]
        public string FileKey { get; set; }

        public long? IndividualId { get; set; }

        public virtual Individual Individual { get; set; }
        public virtual ICollection<Website> Websites { get; set; }
    }
}