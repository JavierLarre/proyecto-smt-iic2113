using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public static class SkillTargetFactory
{
    public static ISkillTargets GetSkillTargets(Skill skill)
    {
        return skill.Target switch
        {
            "Single" => new SingleSkillTarget(),
            "Ally" => new AllySkillTarget(skill.Name),
            _ => throw new ArgumentException("Target Not Implemented", skill.Target)
        };
    }
}