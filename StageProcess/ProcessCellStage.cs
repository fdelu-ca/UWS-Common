using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArcelorMittal.UnifiedWeightSystem.Common.ChainOfStages
{
    public class ProcessCellStage
    {
        public int Id { get; set; }
        public int ProcessCellId { get; set; }
        public Stage Stage  { get; set; }
        [MaxLength(50)]
        public string Worker  { get; set; }
        public Stage NextStage { get; set; }
    }
}
