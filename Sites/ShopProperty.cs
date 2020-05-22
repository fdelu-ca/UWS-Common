using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArcelorMittal.UnifiedWeightSystem.Common.Documentation;

namespace ArcelorMittal.UnifiedWeightSystem.Common.Sites
{
    public class ShopProperty
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Timestamp { get; set; }
        [MaxLength(30)]
        public string Value { get; set; }

        public int ShopPropertyTypeId { get; set; }
        public ShopPropertyType ShopPropertyType { get; set; }
    }
}