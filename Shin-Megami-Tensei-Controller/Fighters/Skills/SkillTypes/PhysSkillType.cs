using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class PhysSkillType: OffensiveSkillType
{
    protected override string GetAffinityFromTarget()
    {
        return Target.GetAffinities().Phys;
    }

    protected override int GetSkillStatFromAttacker()
    {
        return GetAttacker().GetStats().Str;
    }
}