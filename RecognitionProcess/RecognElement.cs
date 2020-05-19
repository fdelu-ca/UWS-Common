using System;
using System.Collections.Generic;
using System.Linq;
using ArcelorMittal.UnifiedWeightSystem.Common.WeightingProcess;

namespace ArcelorMittal.UnifiedWeightSystem.Common.RecognitionProcess
{
    public class RecognElement
    {
        public RecognElement() //RecognitionElement
        {
            RecognPhotos = new List<RecognPhoto>();
        }

        public long Id { get; set; } //[47215] - Ключ
        public byte? OrderNumber { get; set; } //[1] - Порядковый номер
        public DateTimeOffset Timestamp { get; set; } //[08.04.2020 17:06:36] - Время проезда

        public string PathUrl { get; set; } //["/2020-04/08/47215/"] - путь к папке взвешивания на медиа-сервере

        public int? RecognCollectionId { get; set; } //[2] - Ссылка на массив распознавания
        public RecognCollection RecognCollection { get; set; }


        public ICollection<RecognPhoto> RecognPhotos { get; set; } //[,] - Набор фото

        /// <summary>
        ///     Выбор наиболее подходящего номера.
        /// </summary>
        /// <exception cref="System.ArgumentNullException" />
        /// <returns>RecognNumber</returns>
        public string GetRecognNumber()
        {
            return RecognPhotos.OrderByDescending(x => x.Quality).FirstOrDefault()?.RecognNumber;
        }

        /// <summary>
        ///     Возвращает фото номера.
        /// </summary>
        /// <exception cref="System.ArgumentNullException" />
        /// <returns>Photo</returns>
        public byte[] GetPhotoNumber()
        {
            return RecognPhotos.OrderByDescending(x => x.Quality).FirstOrDefault()?.PhotoNumber;
        }
    }
}