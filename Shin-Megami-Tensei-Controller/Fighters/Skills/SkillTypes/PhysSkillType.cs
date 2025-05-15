using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class PhysSkillType: OffensiveSkillType
{
    protected override string GetMadeAction()
    {
        return "ataca a";
    }

    protected override string GetAffinityString(IFighterModel target)
    {
        return target.GetUnitData().Affinities.Phys;
    }

    protected override int GetSkillStatFromAttacker()
    {
        return GetAttacker().GetUnitData().Stats.Str;
    }
}