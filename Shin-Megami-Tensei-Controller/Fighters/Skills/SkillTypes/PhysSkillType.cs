using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class PhysSkillType: OffensiveSkillType
{
    protected override string GetMadeAction()
    {
        return "ataca a";
    }

    protected override string GetAffinityString(IFighter target)
    {
        return target.GetAffinities().Phys;
    }

    protected override int GetSkillStatFromAttacker()
    {
        return GetAttacker().GetStats().Str;
    }
}