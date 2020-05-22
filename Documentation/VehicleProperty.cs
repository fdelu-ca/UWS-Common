using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArcelorMittal.UnifiedWeightSystem.Common.Documentation
{
    public class VehicleProperty
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Timestamp { get; set; }
        [MaxLength(30)]
        public string Value { get; set; }
        
        public int VehiclePropertyTypeId { get; set; } 
        public VehiclePropertyType VehiclePropertyType { get; set; } 
    }
}