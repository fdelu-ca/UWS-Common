using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ArcelorMittal.UnifiedWeightSystem.Common.Logging
{
    class UwsStatus
    {
        public int Id { get; set; }
        public int? ProcessCellId { get; set; }

        public int StatusTypeId { get; set; }
        public UwsStatusType StatusType { get; set; }

        [Column(TypeName = "datetime")] public DateTime Timestamp { get; set; }

        public int? ValueInt { get; set; }
        public string valueChar { get; set; }
    }
    class UwsStatusType
    {
        [DefaultValue("(datediff(second,'1970',getdate()))")] 
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
