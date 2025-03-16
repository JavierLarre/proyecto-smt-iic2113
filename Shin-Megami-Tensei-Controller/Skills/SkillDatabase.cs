using Shin_Megami_Tensei.Common;

namespace Shin_Megami_Tensei.Skills;

public static class SkillDatabase
{
    private static string JsonFile = "skills.json";
    private static List<SkillData> SkillDatas = [];

    private static void GetList()
    {
        if (SkillDatas.Count == 0)
        {
            SkillDatas = JsonParser.DeserializeList<SkillData>(JsonFile);
        }
    }

    public static SkillData Find(string skillName)
    {
        GetList();
        return SkillDatas.First(skill => skill.name == skillName);
    }
}