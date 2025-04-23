namespace Shin_Megami_Tensei_Model;

public abstract class AbstractFighter: IFighter
{
    private string _name;
    private Stats _stats;
    private Affinities _affinities;
    private readonly ICollection<Skill> _skills;

    protected AbstractFighter(string name, ICollection<Skill> skills,
        Stats stats, Affinities affinities)
    {
        _name = name;
        _skills = skills;
        _stats = stats;
        _affinities = affinities;
    }

    public void HealDamage(int amount) => _stats.HealDamage(amount);

    public void RecieveDamage(double damage) => _stats.RecieveDamage(damage);
    

    public void DecreaseMp(int cost) => _stats.DecreaseMp(cost);



    public IEnumerable<Skill> GetAvailableSkills()
    {
        return _skills
            .Where(skill => skill.Cost <= _stats.MpLeft);
    }
    public Affinities GetAffinities() => _affinities;

    public ICollection<Skill> GetSkills() => _skills;

    public Skill GetSkillFromName(string skillName)
    {
        return _skills.First(skill => skill.Name == skillName);
    }

    public bool IsAlive() => _stats.HpLeft > 0;

    public string GetName() => _name;

    public Stats GetStats() => _stats;

    public  abstract IEnumerable<string> GetFightOptions();
}