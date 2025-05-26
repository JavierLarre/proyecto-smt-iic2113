namespace Shin_Megami_Tensei_Model;

public static class GameConstants
{
    public const int MaxSizeFrontRow = 4;

    public static int Truncate(double value)
    {
        return Convert.ToInt32(Math.Floor(value));
    }
}