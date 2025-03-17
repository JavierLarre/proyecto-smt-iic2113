using Shin_Megami_Tensei.ClassesForParsing;

namespace Shin_Megami_Tensei.Monsters;

public class MonsterDataFromJson
{
    public string name { get; set; }
    public StatsDataFromJson stats { get; set; }
    public AffinityDataFromJson affinity { get; set; }
    public List<string> skills { get; set; }
}