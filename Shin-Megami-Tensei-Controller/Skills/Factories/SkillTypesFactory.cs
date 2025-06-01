using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public static class SkillTypesFactory
{
    public static ISkillType GetSkillType(SkillData skillData)
    {
        return skillData.Type switch
        {
            "Phys" => new PhysSkillType(skillData),
            "Gun" => new GunSkillType(skillData),
            "Fire" => new FireSkillType(skillData),
            "Ice" => new IceSkillType(skillData),
            "Elec" => new ElecSkillType(skillData),
            "Force" => new ForceSkillType(skillData),
            "Heal" => new HealSkillType(skillData),
            _ => throw new ArgumentException("Type Not Found", skillData.Type)
        };
    }
    
    private static bool DoesSkillRevive(SkillData skill)
    {
        return skill.Name.Contains("ecarm");
    }
}