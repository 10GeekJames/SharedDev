// This file is generated, don't touch
using Calculator.Models;
using Calculator.Models.RequestResponse;
using System;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models.ViewModels
{
    public partial class UserInRoomVM : BaseEf
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