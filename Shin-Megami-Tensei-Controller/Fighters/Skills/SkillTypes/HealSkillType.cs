using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class HealSkillType: ISkillType
{
    public void ApplyEffect(IFighter target, int power)
    {
        int healAmount = CalculateHealAmount(target, power);
        target.HealDamage(healAmount);
    }

    private static int CalculateHealAmount(IFighter target, int power)
    {
        return (int) Math.Floor(target.GetStats().MaxHp * power * 0.01);
    }
}