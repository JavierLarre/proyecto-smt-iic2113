using Shin_Megami_Tensei.ClassesForParsing;

namespace Shin_Megami_Tensei.Samurais;

public class SamuraiDataFromJson
{
    public string name { get; set; }
    public StatsDataFromJson stats { get; set; }
    public AffinityDataFromJson affinity { get; set; }
}