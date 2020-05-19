using System;
using System.ComponentModel.DataAnnotations;

namespace ArcelorMittal.UnifiedWeightSystem.Common.WeightingProcess
{
    public class WeightCollectionProperty
    {
        public int Id { get; set; }
        public long WeightCollectionId { get; set; }
        public WeightCollection WeightCollection { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        [MaxLength(30)]
        public string Value { get; set; }

        public int WeightPropertyTypeId { get; set; }
        public WeightPropertyType WeightPropertyType { get; set; }
    }
}