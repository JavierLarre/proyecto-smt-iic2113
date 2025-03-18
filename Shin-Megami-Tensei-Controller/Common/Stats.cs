using Shin_Megami_Tensei.DataClassesFromJson;

namespace Shin_Megami_Tensei.Common;

public class Stats
{
    private Dictionary<string, int> StatsMap;

    public static Stats FromData(StatsDataFromJson data)
    {
        return new Stats(data);
    }

    private Stats(StatsDataFromJson data)
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