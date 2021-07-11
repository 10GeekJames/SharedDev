using System;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models
{
    public partial class UserInRoom : BaseEf
    {
        [Key]
        public long Id { get; set; }
        [StringLength(40)]
        public string RoomName { get; set; }
        [StringLength(80)]
        public string UserName { get; set; }
        [StringLength(100)]
        public string ConnectionId { get; set; }
        public bool IsReconnecting { get; set; }
        public bool IsDisconnected { get; set; }
        public DateTime CurrentSessionSince { get; set; }
    }
}