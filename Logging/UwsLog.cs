using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using ArcelorMittal.UnifiedWeightSystem.Common.RecognitionProcess;
using ArcelorMittal.UnifiedWeightSystem.Common.Sites;
using ArcelorMittal.UnifiedWeightSystem.Common.WeightingProcess;

namespace ArcelorMittal.UnifiedWeightSystem.Common.Logging
{
    public class UwsLog
    {
        
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Timestamp { get; set; }
        
        [NotMapped] public InfoLevel InfoLevel;
        public string Level
        {
            get => InfoLevel.ToString();
            set => InfoLevel = (InfoLevel) Enum.Parse(typeof(InfoLevel), value);
        }

        public int? WeightingCollectionId { get; set; }          
        public WeightingCollection WeightingCollection{ get; set; }        
        
        public int? RecognCollectionId { get; set; }          
        // public RecognCollection RecognCollection { get; set; }       
        
        public int? ScalesSerial { get; set; }
        // public Station Station { get; set; }

        public int? UwsLogTypeId { get; set; }
        public UwsLogType UwsLogType { get; set; }
        
        public int? UwsLogDetailId { get; set; }
        public virtual UwsLogDetail UwsLogDetail { get; set; }
    }
}