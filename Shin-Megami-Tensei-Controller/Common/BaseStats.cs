using Shin_Megami_Tensei.ClassesForParsing;

namespace Shin_Megami_Tensei.Common;

public class BaseStats
{
    private Dictionary<string, int> StatsMap;

    public static BaseStats FromData(StatsDataFromJson data)
    {
        return new BaseStats(data);
    }

    private BaseStats(StatsDataFromJson data)
    {
        StatsMap = new Dictionary<string, int>
        {
            ["HP"] = data.HP,
            ["MP"] = data.MP,
            ["Str"] = data.Str,
            ["Skl"] = data.Skl,
            ["Mag"] = data.Mag,
            ["Spd"] = data.Spd,
            ["Lck"] = data.Lck
        };
    }
}