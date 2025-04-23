namespace Shin_Megami_Tensei_Model;

public interface IFighter
{
    public string GetName();
    public Stats GetStats();
    public IEnumerable<string> GetFightOptions();
    public Affinities GetAffinities();
    public ICollection<Skill> GetSkills();
    public IEnumerable<Skill> GetAvailableSkills();
    public Skill GetSkillFromName(string skillName);

    public void HealDamage(int amount);
    public void RecieveDamage(double damage);
    public void DecreaseMp(int cost);
    public bool IsAlive();
}