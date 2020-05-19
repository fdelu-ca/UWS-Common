using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArcelorMittal.UnifiedWeightSystem.Common.Documentation;
using ArcelorMittal.UnifiedWeightSystem.Common.Sites;

namespace ArcelorMittal.UnifiedWeightSystem.Common.WeightingProcess
{
    public class WeightCollection
    {
        //TODO Добавить историю этапов #StageHistory                                   

        public WeightCollection()
        {
            WeightElements = new List<WeightElement>();
        }

        public long Id { get; set; } //[98543] - Ключ        
        public long LocalId { get; set; }
        public ICollection<WeightElement> WeightElements { get; set; } //Конкретные взвешивания(одно Т/С)

        public DateTimeOffset? Begin { get; set; } //Дата начала перевески
        public DateTimeOffset? End { get; set; } //Дата окончания перевески

        // public Station Station { get; set; }//[43] - Станция
        public int? StationId { get; set; } 
        
        [DefaultValue(Direction.Undefined)]
        public Direction Direction { get; set; } // Направление состава
        [DefaultValue(Stage.Undefined)]
        public Stage Stage { get; set; } //[Complite] - Текущий этап
        public bool Release { get; set; }
        
        [MaxLength(30)]
        public string TrainStatus { get; set; } //Статус
    }
}