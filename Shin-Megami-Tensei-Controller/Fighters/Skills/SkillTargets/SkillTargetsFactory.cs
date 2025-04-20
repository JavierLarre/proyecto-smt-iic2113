namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public static class SkillTargetsFactory
{

    public static ISkillTargets GetSkillTargets(string targets)
    {
        return targets switch
        {
            "Single" => new SingleSkillTarget(),
            "Ally" => new AllySkillTarget(),
            _ => throw new NotImplementedException("Target Not Implemented" + targets)
        };
    }
}