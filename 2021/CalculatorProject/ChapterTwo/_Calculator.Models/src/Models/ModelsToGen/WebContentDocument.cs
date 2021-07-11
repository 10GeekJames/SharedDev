using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Calculator.Models
{
    public partial class WebContentDocument : BaseEfAudit
    {
        [Key]
        public long Id { get; set; }
        
    }
}