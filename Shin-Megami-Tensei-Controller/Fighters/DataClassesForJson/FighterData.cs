namespace Shin_Megami_Tensei.Fighters.DataClassesForJson;

public abstract class FighterData
{
    public string name { get; set; }
    public StatsDataFromJson stats { get; set; }
    public AffinityDataFromJson affinity { get; set; }
}