using Shin_Megami_Tensei.Fighters.Actions;
using Shin_Megami_Tensei.Fighters.Skills;

namespace Shin_Megami_Tensei.Fighters;

public abstract class Fighter
{
    public string Name;
    public Stats Stats;
    public Affinities Affinities;
    public Skill[] Skills = [];
    public IAction[] Actions = [];
    
    public override string ToString() => 
        $"{Name} {Stats}";

    public IEnumerable<string> SkillsInString()
    {
        return Skills.Select(skill => skill.ToString());
    }

    public void RecieveDamage(int damage)
    {
        Stats.HpLeft = int.Max(0, Stats.HpLeft - damage);
    }
    
}