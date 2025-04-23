namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class ElecSkillType: OffensiveMagicSkill
{
    protected override string GetAffinityFromTarget()
    {
        return Target.GetAffinities().Elec;
    }
}