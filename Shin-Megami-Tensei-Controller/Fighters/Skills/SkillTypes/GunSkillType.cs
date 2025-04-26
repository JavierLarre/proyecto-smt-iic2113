using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class GunSkillType: OffensiveSkillType
{
    protected override int GetSkillStatFromAttacker()
    {
        return GetAttacker().GetStats().Skl;
    }

    protected override string GetMadeAction()
    {
        return "dispara a";
    }

    protected override string GetAffinityString(IFighter target)
    {
        return target.GetAffinities().Gun;
    }
}