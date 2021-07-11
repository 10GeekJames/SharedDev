// This file is generated, don't touch
using Calculator.Models;
using Calculator.Models.RequestResponse;
using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models.ViewModels
{
    public partial class IndividualInBusinessVM : BaseEfAudit
    {
        public bool? IsActive { get; set; }

        public long BusinessId { get; set; }
        public long IndividualId { get; set; }
        public long RoleLookupTypeId { get; set; }

        public virtual BusinessVM BusinessVM { get; set; }
        public virtual IndividualVM IndividualVM { get; set; }
        public virtual LookupTypeVM RoleLookupTypeVM { get; set; }
    }
}