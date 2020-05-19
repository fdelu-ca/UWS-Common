﻿ namespace ArcelorMittal.UnifiedWeightSystem.Common.Sites
{
    public class Station
    {
        public ushort Id { get; set; }
        public StationType Type { get; set; } //Тип [Внутренняя ЖД]
        public int? ShopId { get; set; } //Id Цеха
        public Shop Shop { get; set; } //Цех в котором находится станция
        public ProcessType ProcessType { get; set; } // Уровень автоматизации перевески

        //TODO Дописать параметры станции, если имеются
    }
}