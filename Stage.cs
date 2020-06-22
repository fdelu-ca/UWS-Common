﻿namespace ArcelorMittal.UnifiedWeightSystem.Common
{
    public enum Stage : int
    {
        //Main Stage
        Weighed       = 0x10,        //Взвешен
        SendToUWS     = 0x20,        //Передан на Sql сервер
        MachiningOver = 0x30,        //Машинная обработка завершена
        Complited     = 0x40,        //Завершена
        Archived      = 0x50,        //Архивированна 
        
        //Sub Stage
        SendToFtp     = 0x21,        //Передан на Ftp сервер
        Recognized    = 0x24,        //Распознан
        UzJoined      = 0x25,        //Распознан
        Checked       = 0x35,        //Данные проверены оператором
        SendToSAP     = 0x47,        //Отправлен в SAP

        //Common
        Undefined     = 0x00,        //Не имеет статуса 
        Defect        = 0xFF,        //Забраковано
    }
}