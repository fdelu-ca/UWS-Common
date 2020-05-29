using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArcelorMittal.UnifiedWeightSystem.Common.WeightingProcess
{
    public class WeightingElementProperty
    {
        public int Id { get; set; }
        public int WeightElementId { get; set; }
        public WeightingElement WeightElement { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Timestamp { get; set; }
        [MaxLength(30)]
        public string Value { get; set; }

        public int WeightingPropertyTypeId { get; set; }
        public WeightingPropertyType WeightingPropertyType { get; set; }
    }
}