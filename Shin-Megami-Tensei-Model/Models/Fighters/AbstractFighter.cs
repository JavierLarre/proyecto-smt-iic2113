namespace Shin_Megami_Tensei_Model;

public abstract class AbstractFighter: IFighter
{
    public string Name { get; }
    public abstract string[] FightOptions { get; }
    public Stats Stats { get; }
    public Affinities Affinities { get; }
    
    private readonly ICollection<Skill> _skills;

    protected AbstractFighter(string name, ICollection<Skill> skills, Stats stats, Affinities affinities)
    {
        Name = name;
        _skills = skills;
        Stats = stats;
        Affinities = affinities;
    }

    public void RecieveDamage(int damage)
    {
        Stats.RecieveDamage(damage);
    }

    public ICollection<Skill> GetSkills() => _skills;

    public IEnumerable<Skill> GetAvailableSkills()
    {
        return _skills
            .Where(skill => skill.Cost <= Stats.MpLeft);
    }

    public Skill GetSkill(string skillName)
    {
        return _skills.First(skill => skill.Name == skillName);
    }

    public bool IsAlive() => Stats.HpLeft > 0;
}