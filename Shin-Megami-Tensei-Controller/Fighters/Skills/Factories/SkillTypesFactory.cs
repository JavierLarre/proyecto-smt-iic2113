using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public static class SkillTypesFactory
{
    public static ISkillType GetSkillType(SkillData skill)
    {
        return skill.Type switch
        {
            "Phys" => new PhysSkillType(),
            "Gun" => new GunSkillType(),
            "Fire" => new FireSkillType(),
            "Ice" => new IceSkillType(),
            "Elec" => new ElecSkillType(),
            "Force" => new ForceSkillType(),
            "Heal" => DoesSkillRevive(skill) ?
                new ReviveSkillType() :
                new HealSkillType(),
            _ => throw new ArgumentException("Type Not Found", skill.Type)
        };
    }
    
    private static bool DoesSkillRevive(SkillData skill)
    {
        return skill.Name.Contains("ecarm");
    }
}