using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArcelorMittal.UnifiedWeightSystem.Common.Documentation;

namespace ArcelorMittal.UnifiedWeightSystem.Common.Sites
{
    public class StationProperty
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public Station Station { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Timestamp { get; set; }
        [MaxLength(30)]
        public string Value { get; set; }

        public int StationPropertyTypeId { get; set; }
        public StationPropertyType StationPropertyType { get; set; }
    }
}