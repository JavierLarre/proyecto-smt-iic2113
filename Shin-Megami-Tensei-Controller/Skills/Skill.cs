namespace Shin_Megami_Tensei.Skills;

public class Skill
{
    public string Name;
    public string Type;
    public int Cost;
    public int Power;
    public string Target;
    public string Hits;
    public string Effect;

    public Skill(SkillDataFromJson data)
    {
        Name = data.name;
        Type = data.type;
        Cost = data.cost;
        Power = data.power;
        Target = data.target;
        Hits = data.hits;
        Effect = data.effect;
    }
}