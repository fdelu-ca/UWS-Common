using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArcelorMittal.UnifiedWeightSystem.Common.Documentation;
using ArcelorMittal.UnifiedWeightSystem.Common.Sites;

namespace ArcelorMittal.UnifiedWeightSystem.Common.WeightingProcess
{
    public class WeightingCollection
    {
        //TODO Добавить историю этапов #StageHistory                                   

        public WeightingCollection()
        {
            WeightingElements = new List<WeightingElement>();
        }

        public int Id { get; set; } //[98543] - Ключ        
        public int LocalId { get; set; }
        public ICollection<WeightingElement> WeightingElements { get; set; } //Конкретные взвешивания(одно Т/С)

        public DateTimeOffset? DtBegin { get; set; } //Дата начала перевески
        public DateTimeOffset? DtEnd { get; set; } //Дата окончания перевески

        // public Station Station { get; set; }//[43] - Станция
        public int? ScalesSerial { get; set; } 
        
        [DefaultValue(Direction.Undefined)]
        public Direction Direction { get; set; } // Направление состава
        [DefaultValue(Stage.Undefined)]
        public Stage Stage { get; set; } //[Complite] - Текущий этап
        public bool Release { get; set; }
        
        [MaxLength(30)]
        public string Status { get; set; } //Статус
    }
}