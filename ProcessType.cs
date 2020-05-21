namespace ArcelorMittal.UnifiedWeightSystem.Common.Sites
{
    public enum ProcessType : int
    {
        ManualStatic = 0, // Статика
        ManualDynamic = 1, // Динамика (без распознавания)
        HumanControl = 2, // Автоматизированное взвешивание (человеческий контроль)
        AutomaticDynamic = 3 // Без участия человека
    }
}