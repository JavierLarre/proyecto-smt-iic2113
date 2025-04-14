namespace Shin_Megami_Tensei_Model;

public interface IFighter
{
    public string Name { get; }
    public Stats Stats { get; }
    public string[] FightOptions { get; }
    public Affinities Affinities { get; }

    public void RecieveDamage(int damage);
    public ICollection<Skill> GetSkills();
    public IEnumerable<Skill> GetAvailableSkills();
    public Skill GetSkill(string skillName);
    public bool IsAlive();
}