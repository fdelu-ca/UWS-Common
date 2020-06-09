using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArcelorMittal.UnifiedWeightSystem.Common.DiagnosticProcess
{
    public class Status
    {
        public int Id { get; set; }

        public int? ProcessCellId { get; set; }

        [MaxLength(50)] 
        public string Value { get; set; }
        public int? StatusTypeId { get; set; }
        public StatusType StatusType { get; set; }

        [Column(TypeName = "datetime"),DefaultValue("(getDate())")]
        public DateTime Timestamp { get; set; }
        public int? Order { get; set; }

        [DefaultValue(1)]
        public bool StatusColor { get; set; }

    }
}