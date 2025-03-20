using Shin_Megami_Tensei.Fighters.Skills;

namespace Shin_Megami_Tensei.Fighters;

public abstract class Fighter
{
    public string Name;
    public Stats Stats;
    public Affinities Affinities;
    public Skill[] Skills = [];
    
    public override string ToString() => 
        $"{Name} {Stats}";

    public IEnumerable<string> SkillsInString()
    {
        return Skills.Select(skill => skill.ToString());
    }
}