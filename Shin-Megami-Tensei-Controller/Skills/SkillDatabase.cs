using Shin_Megami_Tensei.Common;

namespace Shin_Megami_Tensei.Skills;

public static class SkillDatabase
{
    private const string JsonFile = "skills.json";
    private static List<SkillDataFromJson> DataList => 
        JsonDeserializer.DeserializeList<SkillDataFromJson>(JsonFile);

    public static SkillDataFromJson Find(string skillName)
    {
        return DataList.First(skill => skill.name == skillName);
    }
}