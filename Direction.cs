namespace ArcelorMittal.UnifiedWeightSystem.Common
{
    public enum Direction : int
    {
        Arrival = 0,
        Departure = 1,
        //
        North = 3,
        East = 4,
        South = 5,
        West = 6,
        Static = 7,

        NorthEast = 34,
        NorthWest = 36,
        SouthEast = 54,
        SouthWest = 56,

        Undefined = 0xFF
    }
}