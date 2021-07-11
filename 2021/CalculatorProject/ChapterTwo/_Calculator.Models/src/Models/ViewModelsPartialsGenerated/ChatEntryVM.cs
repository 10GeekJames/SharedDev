// This file is generated, don't touch
using Calculator.Models;
using Calculator.Models.RequestResponse;
using System;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models.ViewModels
{
    public partial class ChatEntryVM : BaseEfAudit
    {
        [Key]
        public long Id { get; set; }

        [StringLength(240)]
        public string EntryData { get; set; }

        public long ChatId { get; set; }
        public long IndividualId { get; set; }

        public virtual ChatVM ChatVM { get; set; }
        public virtual IndividualVM IndividualVM { get; set; }
    }
}