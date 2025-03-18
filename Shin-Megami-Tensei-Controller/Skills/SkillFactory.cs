using Shin_Megami_Tensei.Common;

namespace Shin_Megami_Tensei.Skills;

public static class SkillFactory
{
    private const string JsonFile = "skills.json";
    
    private static readonly List<SkillDataFromJson> DataList = 
        JsonDeserializer.DeserializeList<SkillDataFromJson>(JsonFile);

    private static SkillDataFromJson FindByName(string skillName) =>
        DataList.First(skill => skill.name == skillName);

    public static Skill FromName(string name)
    {
        var data = FindByName(name);
        return new Skill(data);
    }
}