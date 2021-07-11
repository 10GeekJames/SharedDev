// This file is generated, don't touch
using Calculator.Models;
using Calculator.Models.RequestResponse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models.ViewModels
{
    public partial class IndividualVM : BaseEf
    {
        [Key]
        public long Id { get; set; }

        [StringLength(200)]
        public string FirstName { get; set; }

        [StringLength(200)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string EmailAddress { get; set; }

        [StringLength(400)]
        public string ImageUrl { get; set; }
        public Guid? WebId { get; set; }

        [StringLength(20)]
        public string tzAbbr { get; set; }
        [StringLength(140)]
        public string tzName { get; set; }
        [StringLength(20)]
        public string tzOffset { get; set; }
        public virtual ICollection<BusinessVM> BusinessesVM { get; set; }
        public virtual ICollection<ChatVM> ChatsVM { get; set; }
        public virtual ICollection<ChatEntryVM> ChatEntriesVM { get; set; }
        public virtual ICollection<ChatIndividualVM> ChatIndividualsVM { get; set; }
        
        public virtual ICollection<RoomVM> RoomsVM { get; set; }
        public virtual ICollection<Calculator2CharacterVM> Calculator2CharactersVM { get; set; }
        public virtual ICollection<IndividualInBusinessVM> IndividualsInBusinessesVM { get; set; }
    }
}