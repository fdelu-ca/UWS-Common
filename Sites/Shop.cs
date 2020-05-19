﻿namespace ArcelorMittal.UnifiedWeightSystem.Common.Sites
{
    public class Shop //Цех
    {
        public int Id { get; set; } //
        public string Name { get; set; } //

        public Shop ParentShop { get; set; } // Цех предок ?? null
        //TODO Дописать все типы в Цех
    }
}