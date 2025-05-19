namespace Shin_Megami_Tensei_Model;

public struct UnitData
{
    public string Name;
    public Stats Stats;
    public Affinities Affinities;
    public ICollection<string> FightOptions;
    public ICollection<SkillData> Skills;
    public int FilePriority;
}