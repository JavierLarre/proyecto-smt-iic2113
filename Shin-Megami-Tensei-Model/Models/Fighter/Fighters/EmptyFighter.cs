namespace Shin_Megami_Tensei_Model.Fighters;

public class EmptyFighter: IFighter
{
    public string GetName() => "";
    public Stats GetStats() => new Stats();
    public IEnumerable<string> GetFightOptions() => [];
    public Affinities GetAffinities() => new Affinities();
    public void HealDamage(int amount)
    {
    }

    public void RecieveDamage(double damage)
    {
    }

    public void DecreaseMp(int cost)
    {
    }

    public ICollection<Skill> GetSkills() => [];

    public IEnumerable<Skill> GetAvailableSkills() => [];

    public Skill GetSkillFromName(string skillName) => new Skill();

    public bool IsAlive() => false;
}