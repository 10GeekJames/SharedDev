using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models
{
    public partial class IndividualInBusiness : BaseEfAudit
    {
        public bool? IsActive { get; set; }

        public long BusinessId { get; set; }
        public long IndividualId { get; set; }
        public long RoleLookupTypeId { get; set; }

        public virtual Business Business { get; set; }
        public virtual Individual Individual { get; set; }
        public virtual LookupType RoleLookupType { get; set; }
    }
}