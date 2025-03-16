using Shin_Megami_Tensei.ClassesForParsing;

namespace Shin_Megami_Tensei.Monsters;

public class MonsterData
{
    public string name { get; set; }
    public StatsInfo stats { get; set; }
    public AffinityInfo affinity { get; set; }
    public List<string> skills { get; set; }
}