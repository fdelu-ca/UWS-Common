namespace ArcelorMittal.UnifiedWeightSystem.Common.Sites
{
    public enum StationType : byte //0x00 => Type|Vehicle
    {
        CarInternal = 0x00,
        TrainInternal = 0x01,
        CarExternal = 0x10,
        TrainExternal = 0x11
    }
}