using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Emit;
using ArcelorMittal.UnifiedWeightSystem.Common.Documentation;

namespace ArcelorMittal.UnifiedWeightSystem.Common.WeightingProcess
{
    public class WeightElement
    {
        public WeightElement()
        {
            // Status = new List<ElemInform>();
        }

        public long Id { get; set; } //[45671] - Уникальный id перевески
        public byte? OrderNumber { get; set; } //[1] - Порядковый номер
        public DateTimeOffset Timestamp { get; set; } //[08.04.2020 17:06:36] -

        public long? WeightCollectionId { get; set; } //[1] - Перевеска
        public WeightCollection WeightCollection { get; set; }

        //Vehicle
        public int? VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        [DefaultValue(VehicleType.Undefined)]
        public VehicleType VehicleType { get; set; }
        public int? AxisCount { get; set; }
        public int? Length { get; set; }
        
        //Weighting
        [DefaultValue(TypeWeight.Undefined)]
        public TypeWeight TypeWeight { get; set; } //[Bruto] - Тип веса
        public double? Weight { get; set; } //[112.4] - Фактический вес
        public double? Speed { get; set; } //Скорость Т/С
        public byte Quality { get; set; } //Качество взвешивания
        
        
    }
}