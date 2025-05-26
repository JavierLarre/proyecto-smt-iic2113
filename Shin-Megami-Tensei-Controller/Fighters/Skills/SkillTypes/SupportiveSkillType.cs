using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public abstract class SupportiveSkillType: ISkillType
{
    public void ApplyEffect(IFighterModel target, int power)
    {
        double healAmount = CalculateHealAmount(target, power);
        int targetHp = target.GetCurrentHp();
        target.SetHp(targetHp + GameConstants.Truncate(healAmount));
    }

    protected static double CalculateHealAmount(IFighterModel target, int power)
    {
        return target.GetUnitData().Stats.Hp * power * 0.01;
    }

    public IAffinityController GetTargetAffinity(IFighterModel target)
    {
        return new NeutralAffinity();
    }

    public abstract string ToString(IFighterModel target, int power);
}