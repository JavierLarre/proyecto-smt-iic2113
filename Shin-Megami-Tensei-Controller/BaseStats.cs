using Shin_Megami_Tensei.ClassesForParsing;

namespace Shin_Megami_Tensei;

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