// This file is generated, don't touch
using Calculator.Models;
using Calculator.Models.RequestResponse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Calculator.Models.ViewModels
{
    public partial class ChatVM : BaseEfAudit
    {
        public ChatVM()
        {
            this.ChatEntriesVM = new HashSet<ChatEntryVM>();
        }

        [Key]
        public long Id { get; set; }

        public bool IsInviteOnly { get; set; }
        public bool? IsListedInDirectory { get; set; }

        public virtual HashSet<ChatEntryVM> ChatEntriesVM { get; set; }
    }
}