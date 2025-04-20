namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public static class SkillTypesFactory
{
    public static ISkillType GetSkillType(string type)
    {
        return type switch
        {
            "Phys" => new PhysSkillType(),
            "Gun" => new GunSkillType(),
            "Fire" => new FireSkillType(),
            "Ice" => new IceSkillType(),
            "Elec" => new ElecSkillType(),
            "Force" => new ForceSkillType(),
            "Heal" => new HealSkillType(),
            "Special" => new SpecialSkillType(),
            _ => throw new NotImplementedException("Type Not Implemented" + type)
        };
    }
}