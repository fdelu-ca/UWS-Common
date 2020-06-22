using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using ArcelorMittal.UnifiedWeightSystem.Common.Documentation;

namespace ArcelorMittal.UnifiedWeightSystem.Common.WeightingProcess
{
    public class WeightingElement
    {
        public WeightingElement()
        {
            // Status = new List<ElemInform>();
        }

        public int Id { get; set; } //[45671] - Уникальный id перевески
        public int? OrderNumber { get; set; } //[1] - Порядковый номер
        [Column(TypeName = "datetime")]
        public DateTime Timestamp { get; set; } //[08.04.2020 17:06:36] -

        public int? WeightingCollectionId { get; set; } //[1] - Перевеска
        public WeightingCollection WeightingCollection { get; set; }

        //Vehicle
        public int? VehicleId { get; set; }
        // public Vehicle Vehicle { get; set; }
        [DefaultValue(VehicleType.Undefined)]
        public VehicleType VehicleType { get; set; }
        public int? AxisCount { get; set; }
        public int? Length { get; set; }
        public int? WeightingOperationsId{ get; set; }
        [MaxLength(10)]
        public string RecNumber{ get; set; }


        //Weighting
        [DefaultValue(TypeWeight.Undefined)]
        public TypeWeight TypeWeight { get; set; } //[Bruto] - Тип веса
        public int Weight { get; set; } //[112.4] - Фактический вес
        public double? Speed { get; set; } //Скорость Т/С
        public int Quality { get; set; } //Качество взвешивания

        public int? WayBillId { get; set; } //Путевая

    }
}