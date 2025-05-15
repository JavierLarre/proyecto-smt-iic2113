using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public static class SkillTypesFactory
{
    public static ISkillType GetSkillType(Skill skill)
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
            "Special" => new SpecialSkillType(),
            _ => throw new ArgumentException("Type Not Found", skill.Type)
        };
    }
    
    private static bool DoesSkillRevive(Skill skill)
    {
        return skill.Name.Contains("ecarm");
    }
}