using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using ArcelorMittal.UnifiedWeightSystem.Common.Sites;
using ArcelorMittal.UnifiedWeightSystem.Common.WeightingProcess;

namespace ArcelorMittal.UnifiedWeightSystem.Common.RecognitionProcess
{
    public class RecognCollection
    {
        public RecognCollection()
        {
            RecognElements = new List<RecognElement>();
        }

        public int Id { get; set; } // Ключ    
        [Column(TypeName = "datetime")]
        public DateTime? Begin { get; set; } // Дата начала перевески
        [Column(TypeName = "datetime")]
        public DateTime? End { get; set; } // Дата окончания перевески

        public int? StationId { get; set; } // Станция (+цех)
        // public Station Station { get; set; }
        public ICollection<RecognElement> RecognElements { get; set; } // Список транспортных средств
        
        [DefaultValue(false)]
        public bool Found { get; set; } // Найдено ли событие Shipment

        [DefaultValue(Direction.Undefined)]
        public Direction Direction { get; set; } // Направление состава
    }
}