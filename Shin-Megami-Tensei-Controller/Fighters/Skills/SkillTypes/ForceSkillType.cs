using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class ForceSkillType: OffensiveMagicSkill
{
    protected override string GetMadeAction()
    {
        return "lanza viento a";
    }

    protected override string GetAffinityString(IFighterModel target)
    {
        return target.GetUnitData().Affinities.Force;
    }
}