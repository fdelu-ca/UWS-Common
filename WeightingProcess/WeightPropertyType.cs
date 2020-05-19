﻿using System.ComponentModel.DataAnnotations;

namespace ArcelorMittal.UnifiedWeightSystem.Common.WeightingProcess
{
    public class WeightPropertyType
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
    }
}