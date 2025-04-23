using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public abstract class OffensiveSkillType: ISkillType
{
    protected IFighter Target = null!;
    protected int SkillPower = 0;
    
    public void ApplyEffect(IFighter target, int power)
    {
        Target = target;
        SkillPower = power;
        double damage = CalculateTotalDamage();
        target.RecieveDamage(damage);
    }

    private double CalculateTotalDamage()
    {
        double baseDamage = CalculateSkillDamage();
        IAffinityController affinity = GetAffinity();
        return affinity.CalculateDamage(baseDamage);
    }

    private double CalculateSkillDamage()
    {
        int stat = GetSkillStatFromAttacker();
        return Math.Sqrt(stat * SkillPower);
    }

    private IAffinityController GetAffinity()
    {
        string affinity = GetAffinityFromTarget();
        AffinityFactory factory = new AffinityFactory(affinity);
        return factory.GetAffinity();
    }

    protected IFighter GetAttacker()
    {
        Table table = Table.GetInstance();
        return table.GetCurrentFighter();
    }

    protected abstract string GetAffinityFromTarget();
    protected abstract int GetSkillStatFromAttacker();
}