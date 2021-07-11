using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Calculator.Models
{
    public partial class Room : BaseEfAudit
    {
        [Key]
        public long Id { get; set; }

        [StringLength(400)]
        public string RoomKey { get; set; }
        [StringLength(250)]
        public string SecretSalty { get; set; }
        [StringLength(250)]
        public string LiveInteractQaSystemKeyId { get; set; }
        [StringLength(250)]
        public string LiveInteractStreamViewKeyId { get; set; }

        public long? ProductEventId { get; set; }
        public long? ProductId { get; set; }
        public long IndividualId { get; set; }
        public virtual Individual Individual { get; set; }        
    }
}