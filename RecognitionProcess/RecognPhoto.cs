﻿using System.ComponentModel.DataAnnotations;

 namespace ArcelorMittal.UnifiedWeightSystem.Common.RecognitionProcess
{
    public class RecognPhoto
    {
        public int Id { get; set; }
        
        [MaxLength(20)]
        public string RecognNumber { get; set; } //[19300654] - Считанный номер
        public byte Quality { get; set; } //[72] - Качество картинки
        public byte[] PhotoNumber { get; set; } //[image] - wagon image(cut)
        /* Using byte Photo
         using (var ms = new MemoryStream(byteArrayIn))
         
        {
            return Image.FromStream(ms);
        }
        */
    }
}