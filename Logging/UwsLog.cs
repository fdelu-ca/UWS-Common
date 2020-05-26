using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using ArcelorMittal.UnifiedWeightSystem.Common.RecognitionProcess;
using ArcelorMittal.UnifiedWeightSystem.Common.Sites;
using ArcelorMittal.UnifiedWeightSystem.Common.WeightingProcess;
using Microsoft.Extensions.Logging;

namespace ArcelorMittal.UnifiedWeightSystem.Common.Logging
{
    public class UwsLog
    {

        public int Id { get; set; }
        public int? ProcessCellId { get; set; }
        public string Logger { get; set; }
        [Column(TypeName = "datetime")] public DateTime Timestamp { get; set; }

        [NotMapped] public LogLevel LogLevel;
        [MaxLength(12)] public string Level
        {
            get => LogLevel.ToString();
            set => LogLevel = (LogLevel)Enum.Parse(typeof(LogLevel), value);
        }

        public string Message { get; set; }
        public string Callsite { get; set; }
        public string Exception { get; set; }
    }
}