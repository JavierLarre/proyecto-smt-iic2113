using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public static class SkillTargetsFactory
{
    public static ISkillTargets GetSkillTargets(SkillData skill)
    {
        return skill.Target switch
        {
            "Single" => new SingleSkillTarget(),
            "Ally" => new AllySkillTarget(skill.Name),
            "Party" => new PartyTargets(),
            _ => throw new ArgumentException("Target Not Implemented", skill.Target)
        };
    }
}