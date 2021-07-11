using System;
using System.Collections.Generic;


namespace Calculator.Models
{
    public partial class ActiveUserData
    {
        public ActiveUserData()
        {
            Chats = new HashSet<Chat>();
        }

        public string cEmailAddress { get; set; }
        public string cUserName { get; set; }
        public string cUserId { get; set; }
        public bool Validated { get; set; }
        public bool Initialized { get; set; }

        public long IndividualId { get; set; }

        public virtual Individual Individual { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
    }
}