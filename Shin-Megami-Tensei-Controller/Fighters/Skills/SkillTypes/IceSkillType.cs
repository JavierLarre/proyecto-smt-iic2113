namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class IceSkillType: OffensiveMagicSkill
{
    protected override string GetAffinityFromTarget()
    {
        return Target.GetAffinities().Ice;
    }
}