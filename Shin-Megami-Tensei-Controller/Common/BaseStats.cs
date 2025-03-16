using Shin_Megami_Tensei.ClassesForParsing;

namespace Shin_Megami_Tensei.Common;

public class BaseStats
{
    private Dictionary<string, int> Stats;

    public BaseStats()
    {
        Stats = new Dictionary<string, int>();
    }

    public static BaseStats FromInfo(StatsInfo statsInfo)
    {
        BaseStats baseStats = new BaseStats();
        baseStats.Stats = new Dictionary<string, int>
        {
            ["HP"] = statsInfo.HP,
            ["MP"] = statsInfo.MP,
            ["Str"] = statsInfo.Str,
            ["Skl"] = statsInfo.Skl,
            ["Mag"] = statsInfo.Mag,
            ["Spd"] = statsInfo.Spd,
            ["Lck"] = statsInfo.Lck
        };
        return baseStats;
    }
}

/*
public class BaseStats
{
    public int HP = 0;
    public int MP = 0;
    public int Str = 0;
    public int Skl = 0;
    public int Mag = 0;
    public int Spd = 0;
    public int Lck = 0;

    public static BaseStats FromInfo(StatsInfo statsInfo)
    {
        BaseStats baseStats = new BaseStats
        {
            HP = statsInfo.HP,
            MP = statsInfo.MP,
            Str = statsInfo.Str,
            Skl = statsInfo.Skl,
            Mag = statsInfo.Mag,
            Spd = statsInfo.Spd,
            Lck = statsInfo.Lck
        };
        return baseStats;
    }
}
*/