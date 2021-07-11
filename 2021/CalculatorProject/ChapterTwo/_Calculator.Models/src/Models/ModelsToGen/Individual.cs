using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models
{
    public partial class Individual : BaseEf
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
        public virtual ICollection<Business> Businesses { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<ChatEntry> ChatEntries { get; set; }
        public virtual ICollection<ChatIndividual> ChatIndividuals { get; set; }
        
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Calculator2Character> Calculator2Characters { get; set; }
        public virtual ICollection<IndividualInBusiness> IndividualsInBusinesses { get; set; }
    }
}