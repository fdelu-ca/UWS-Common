using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArcelorMittal.UnifiedWeightSystem.Common.WeightingProcess
{
    public class WeightingCollectionProperty
    {
        public int Id { get; set; }
        public int WeightingCollectionId { get; set; }
        public WeightingCollection WeightingCollection { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        [MaxLength(30)]
        public string Value { get; set; }

        public int WeightPropertyTypeId { get; set; }
        public WeightingPropertyType WeightingPropertyType { get; set; }
    }
}