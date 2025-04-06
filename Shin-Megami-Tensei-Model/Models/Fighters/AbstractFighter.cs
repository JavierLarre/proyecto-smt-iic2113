namespace Shin_Megami_Tensei_Model;

public abstract class AbstractFighter: IFighter
{
    public string Name { get; }
    public string[] FightOptions { get; }
    public Skill[] Skills { get; }
    public Stats Stats { get; }
    public Affinities Affinities { get; }

    protected AbstractFighter(string name, string[] fightOptions,
        Skill[] skills, Stats stats, Affinities affinities)
    {
        Name = name;
        FightOptions = fightOptions;
        Skills = skills;
        Stats = stats;
        Affinities = affinities;
    }
}