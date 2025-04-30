using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public abstract class OffensiveSkillType: ISkillType
{
    private int _skillPower;
    
    public void ApplyEffect(IFighter target, int power)
    {
        _skillPower = power;
        double baseDamage = CalculateSkillDamage();
        IAffinityController affinity = GetTargetAffinity(target);
        affinity.RecieveAttack(target, baseDamage);
        
    }

    private double CalculateSkillDamage()
    {
        int stat = GetSkillStatFromAttacker();
        return Math.Sqrt(stat * _skillPower);
    }

    public IAffinityController GetTargetAffinity(IFighter target)
    {
        string affinity = GetAffinityString(target);
        AffinityFactory factory = new AffinityFactory(affinity);
        return factory.GetAffinity();
    }

    public string ToString(IFighter target, int power)
    {
        string actionMade = GetMadeAction();
        IAffinityController affinity = GetTargetAffinity(target);
        IFighter attacker = Table.GetInstance().GetCurrentFighter();
        string header = $"{attacker.GetUnitData().Name} {actionMade} {target.GetUnitData().Name}";
        return header + '\n' + affinity.GetEffectString(target, CalculateSkillDamage());
    }

    protected abstract string GetMadeAction();

    protected IFighter GetAttacker()
    {
        Table table = Table.GetInstance();
        return table.GetCurrentFighter();
    }

    protected abstract string GetAffinityString(IFighter target);
    protected abstract int GetSkillStatFromAttacker();
}