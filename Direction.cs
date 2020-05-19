namespace ArcelorMittal.UnifiedWeightSystem.Common
{
    public enum Direction : byte
    {
        North = 1,
        East = 2,
        South = 3,
        West = 4,
        Static = 5,

        NorthEast = 12,
        NorthWest = 14,
        SouthEast = 32,
        SouthWest = 34,

        Undefined = 0x00
    }
}