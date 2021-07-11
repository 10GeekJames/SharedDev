﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models
{

    public partial class Calculator2Character : BaseEfAudit
    {
        [Key]
        public long Id { get; set; }

        [StringLength(80)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Avatar { get; set; }
        [StringLength(250)]
        public string Bio { get; set; }
        [StringLength(250)]
        public string WhatISeek { get; set; }
        [StringLength(250)]
        public string WhyMe { get; set; }
        [StringLength(250)]
        public string WhyYou { get; set; }

        public decimal IntensityRating { get; set; }
        public decimal SkillRating { get; set; }
        public decimal ExperienceRating { get; set; }

        public long IndividualId { get; set; }
        public virtual Individual Individual { get; set; }
        
    }
}
