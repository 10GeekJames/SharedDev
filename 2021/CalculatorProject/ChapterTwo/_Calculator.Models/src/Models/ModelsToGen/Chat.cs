using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Calculator.Models
{
    public partial class Chat : BaseEfAudit
    {
        public Chat()
        {
            this.ChatEntries = new HashSet<ChatEntry>();
        }

        [Key]
        public long Id { get; set; }

        public bool IsInviteOnly { get; set; }
        public bool? IsListedInDirectory { get; set; }

        public virtual HashSet<ChatEntry> ChatEntries { get; set; }
    }
}