namespace Shin_Megami_Tensei.Fighters.Skills;

public class Skill(SkillDataFromJson data)
{
    public string Name = data.name;
    public string Type = data.type;
    public int Cost = data.cost;
    public int Power = data.power;
    public string Target = data.target;
    public string Hits = data.hits;
    public string Effect = data.effect;

    public string PrintNameAndCost()
    {
        return $"{Name} MP:{Cost}";
    }
}