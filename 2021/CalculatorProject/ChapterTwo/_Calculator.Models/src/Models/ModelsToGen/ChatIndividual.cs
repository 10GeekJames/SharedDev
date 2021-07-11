using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Calculator.Models
{
    public partial class ChatIndividual : BaseEfAudit
    {
        [Key]
        public long Id { get; set; }

        public long ChatId { get; set; }
        public long IndividualId { get; set; }

        public virtual Chat Chat { get; set; }
        public virtual Individual Individual { get; set; }
    }
}