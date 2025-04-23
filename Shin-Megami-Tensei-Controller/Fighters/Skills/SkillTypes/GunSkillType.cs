using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class GunSkillType: OffensiveSkillType
{
    protected override int GetSkillStatFromAttacker()
    {
        return GetAttacker().GetStats().Skl;
    }

    protected override string GetAffinityFromTarget()
    {
        return Target.GetAffinities().Gun;
    }
}