namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public static class SkillTypesFactory
{
    public static ISkillType GetSkillType(string type, string skillName)
    {
        return type switch
        {
            "Phys" => new PhysSkillType(),
            "Gun" => new GunSkillType(),
            "Fire" => new FireSkillType(),
            "Ice" => new IceSkillType(),
            "Elec" => new ElecSkillType(),
            "Force" => new ForceSkillType(),
            "Heal" => DoesSkillRevive(skillName) ?
                new ReviveSkillType() :
                new HealSkillType(),
            "Special" => new SpecialSkillType(),
            _ => throw new ArgumentException("Type Not Found: " + type)
        };
    }
    
    private static bool DoesSkillRevive(string skillName)
    {
        return skillName.Contains("ecarm");
    }
}