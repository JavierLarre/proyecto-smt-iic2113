namespace Shin_Megami_Tensei_Model;
public abstract class FighterDataForJson
{
    public string name { get; set; }
    public StatsDataFromJson stats { get; set; }
    public AffinityDataFromJson affinity { get; set; }
}