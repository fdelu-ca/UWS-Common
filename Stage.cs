﻿namespace ArcelorMittal.UnifiedWeightSystem.Common
{
    public enum Stage : int
    {
        //Main Stage
        Created             = 0x01,        //Создан
        Weighed             = 0x10,        //Взвешен
        SendToUWS           = 0x20,        //Передан на Sql сервер
        MachiningOver       = 0x30,        //Машинная обработка завершена
        Complited           = 0x40,        //Завершена
        Archived            = 0x50,        //Архивированна 
        TestingZone         = 0xF0,        //Архивированна 

        //Sub Stage
        SendToFtp           = 0x21,        //Передан на Ftp сервер
        Recognized          = 0x24,        //Распознан
        WaitingJoinUZ       = 0x32,        //Обновление вагонов с сервера UZ
        Checked             = 0x35,        //Данные проверены оператором
        DocFormating        = 0x37,        //Ожидание формирования
        SendToSAP           = 0x47,        //Отправлен в SAP

        TestingZone1        = 0xF1,        //Архивированна 
        TestingZone2        = 0xF2,        //Архивированна 
        TestingZone3        = 0xF3,        //Архивированна 
        TestingZone4        = 0xF4,        //Архивированна 
        TestingZone5        = 0xF5,        //Архивированна 
        TestingZone6        = 0xF6,        //Архивированна 

        //Common
        Undefined           = 0x00,        //Не имеет статуса 
        Defect              = 0xFF,        //Забраковано
    }
}