namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class FireSkillType: OffensiveMagicSkill
{
    protected override string GetAffinityFromTarget()
    {
        return Target.GetAffinities().Fire;
    }
}