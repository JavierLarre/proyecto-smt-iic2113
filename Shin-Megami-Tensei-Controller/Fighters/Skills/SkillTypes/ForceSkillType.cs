namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class ForceSkillType: OffensiveMagicSkill
{
    protected override string GetAffinityFromTarget()
    {
        return Target.GetAffinities().Force;
    }
}