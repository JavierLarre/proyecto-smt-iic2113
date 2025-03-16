namespace Shin_Megami_Tensei.Skills;

public class Skill
{
    public string Name = "";
    public string Type = "";
    public int Cost = 0;
    public int Power = 0;
    public string Target = "";
    public string Hits = "";
    public string Effect = "";

    public void FromData(SkillData skillData)
    {
        Name = skillData.name;
        Type = skillData.type;
        Cost = skillData.cost;
        Power = skillData.power;
        Target = skillData.target;
        Hits = skillData.hits;
        Effect = skillData.effect;
    }

    public Skill(string name)
    {
        SkillData skillData = SkillDatabase.Find(name);
        FromData(skillData);
    }

    public new string ToString()
    {
        return Name;
    }
}