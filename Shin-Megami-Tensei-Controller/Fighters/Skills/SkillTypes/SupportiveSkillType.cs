using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public abstract class SupportiveSkillType: ISkillType
{
    public void ApplyEffect(IFighter target, int power)
    {
        double healAmount = CalculateHealAmount(target, power);
        target.HealDamage(healAmount);
    }

    protected static double CalculateHealAmount(IFighter target, int power)
    {
        return target.GetStats().MaxHp * power * 0.01;
    }

    public IAffinityController GetTargetAffinity(IFighter target)
    {
        return new NeutralAffinity();
    }

    public abstract string ToString(IFighter target, int power);
}