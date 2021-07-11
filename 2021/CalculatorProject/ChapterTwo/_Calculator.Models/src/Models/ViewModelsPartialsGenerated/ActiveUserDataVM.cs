// This file is generated, don't touch
using Calculator.Models;
using Calculator.Models.RequestResponse;
using System;
using System.Collections.Generic;


namespace Calculator.Models.ViewModels
{
    public partial class ActiveUserDataVM {
        public ActiveUserDataVM()
        {
            ChatsVM = new HashSet<ChatVM>();
        }

        public string cEmailAddress { get; set; }
        public string cUserName { get; set; }
        public string cUserId { get; set; }
        public bool Validated { get; set; }
        public bool Initialized { get; set; }

        public long IndividualId { get; set; }

        public virtual IndividualVM IndividualVM { get; set; }
        public virtual ICollection<ChatVM> ChatsVM { get; set; }
    }
}