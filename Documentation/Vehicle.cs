using System.Collections.Generic;
 using System.ComponentModel;
using System.Security.Cryptography;
 using System.Text;

 namespace ArcelorMittal.UnifiedWeightSystem.Common.Documentation
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        
        [DefaultValue(VehicleType.Undefined)]
        public VehicleType VehicleType { get; set; }
        public string Number { get; set; }
        public double FactoryTara { get; set; }
        public ICollection<VehicleProperty> VehicleProperties { get; set; }

        public Vehicle()
        {
            VehicleProperties = new List<VehicleProperty>();
        }
    }
}