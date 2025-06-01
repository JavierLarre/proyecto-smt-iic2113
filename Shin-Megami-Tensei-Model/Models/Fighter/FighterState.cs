namespace Shin_Megami_Tensei_Model.Models.Fighter;

public struct FighterState
{
    public string Name;
    public Stats Stats;
    public Affinities Affinities;
    public ICollection<string> FightOptions;
    public ICollection<SkillData> Skills;
    public ICollection<SkillData> UsableSkills;
    public int CurrentHp;
    public int MaxHp;
    public int CurrentMp;
    public int MaxMp;
    public bool IsAlive;
    public bool CanBeSwapped;
    public int FilePriority;
}