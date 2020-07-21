using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using ArcelorMittal.UnifiedWeightSystem.Common.RecognitionProcess;
using ArcelorMittal.UnifiedWeightSystem.Common.Sites;
using ArcelorMittal.UnifiedWeightSystem.Common.WeightingProcess;
using Microsoft.Extensions.Logging;

namespace ArcelorMittal.UnifiedWeightSystem.Common.DiagnosticProcess
{
    public class LogData
    {

        public int Id { get; set; }
        public int? ProcessCellId { get; set; }
        public string Logger { get; set; }
        public DateTimeOffset Timestamp { get; set; }

        [NotMapped] public NLog.LogLevel LogLevel;
        [MaxLength(5)]
        public string Level
        {
            get => LogLevel.ToString();
            set => LogLevel = (NLog.LogLevel)Enum.Parse(typeof(NLog.LogLevel), value);
        }

        public string Message { get; set; }
        public string Callsite { get; set; }
        public string Exception { get; set; }
    }
}