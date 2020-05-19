using System;
using System.ComponentModel.DataAnnotations;

namespace ArcelorMittal.UnifiedWeightSystem.Common.Documentation
{
    public class VehicleProperty
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        [MaxLength(30)]
        public string Value { get; set; }
        
        public int VehiclePropertyTypeId { get; set; } 
        public VehiclePropertyType VehiclePropertyType { get; set; } 
    }
}