using Shin_Megami_Tensei.Fighters.Actions;
using Shin_Megami_Tensei.Fighters.Skills;

namespace Shin_Megami_Tensei.Fighters;

public abstract class Fighter
{
    public string Name = "";
    public Stats Stats;
    public Affinities Affinities;
    public Skill[] Skills = [];
    public IAction[] Actions = [];
    
    public virtual string PrintNameAndStats() => 
        $"{Name} {Stats.PrintStats()}";
    public IEnumerable<Skill> AvailableSkills() => Skills.Where(IsUsable);
    public bool IsUsable(Skill skill) => skill.Cost <= Stats.MpLeft;
    public bool IsAlive() => Stats.HpLeft > 0;
    public void RecieveDamage(int damage) =>
        Stats.HpLeft = int.Max(0, Stats.HpLeft - damage);
}