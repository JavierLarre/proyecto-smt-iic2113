namespace Shin_Megami_Tensei.DataClassesFromJson;

public abstract class AbstractFighterData
{
    public string name { get; set; }
    public StatsDataFromJson stats { get; set; }
    public AffinityDataFromJson affinity { get; set; }
}