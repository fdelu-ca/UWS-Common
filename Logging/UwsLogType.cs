﻿using System.ComponentModel.DataAnnotations;

namespace ArcelorMittal.UnifiedWeightSystem.Common.Logging
{
    public class UwsLogType
    {
        public int Id { get; set; }
        public int Key { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
    }
}