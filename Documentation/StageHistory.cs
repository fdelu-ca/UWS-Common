using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ArcelorMittal.UnifiedWeightSystem.Common.WeightingProcess;

namespace ArcelorMittal.UnifiedWeightSystem.Common.Documentation
{
    public class StageHistory
    {
        public int Id { get; set; }  
        
        public int? LastStageId { get; set; }   
        public StageHistory LastStage { get; set; }   
        [Column(TypeName = "datetime")]
        public DateTime Timestamp{ get; set; }       // Время изменения
        public Stage Stage{ get; set; }              // Новое состояние системы
        
        public int? WeightingCollectionId{ get; set; }          
        public WeightingCollection WeightingCollection { get; set; }        // Перевеска

        
        //TODO Add Domain Authorization
        // public int? UserId{ get; set; }              
        //public User User{ get; set; }              // Пользователь который обновил состояние перевески
    }
}