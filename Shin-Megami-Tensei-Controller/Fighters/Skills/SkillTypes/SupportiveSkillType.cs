using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public abstract class SupportiveSkillType: ISkillType
{
    public void ApplyEffect(IFighter target, int power)
    {
        double healAmount = CalculateHealAmount(target, power);
        int targetHp = target.GetCurrentHp();
        target.SetHp(targetHp + Constants.Truncate(healAmount));
    }

    protected static double CalculateHealAmount(IFighter target, int power)
    {
        return target.GetUnitData().Stats.Hp * power * 0.01;
    }

    public IAffinityController GetTargetAffinity(IFighter target)
    {
        return new NeutralAffinity();
    }

    public abstract string ToString(IFighter target, int power);
}