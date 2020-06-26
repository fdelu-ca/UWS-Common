﻿namespace ArcelorMittal.UnifiedWeightSystem.Common
{
    public enum Stage : int
    {
        //Main Stage
        Weighed             = 0x10,        //Взвешен
        SendToUWS           = 0x20,        //Передан на Sql сервер
        MachiningOver       = 0x30,        //Машинная обработка завершена
        Complited           = 0x40,        //Завершена
        Archived            = 0x50,        //Архивированна 
        
        //Sub Stage
        SendToFtp           = 0x21,        //Передан на Ftp сервер
        Recognized          = 0x24,        //Распознан
        WaitingJoinUZ       = 0x32,        //Обновление вагонов с сервера UZ
        Checked             = 0x35,        //Данные проверены оператором
        WaitDocFormating    = 0x37,        //Ожидание формирования
        SendToSAP           = 0x47,        //Отправлен в SAP

        //Common
        Undefined           = 0x00,        //Не имеет статуса 
        Defect              = 0xFF,        //Забраковано
    }
}