using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Fighters;
using Shin_Megami_Tensei_View.Views;
using Shin_Megami_Tensei_View.Views.ConsoleView;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public abstract class OffensiveSkillType: ISkillType
{
    private SkillData _skillData;
    private IFighterModel _attacker = new EmptyFighter();
    private IFighterModel _target = new EmptyFighter();
    private IAffinityController _affinity = new NeutralAffinity();
    
    protected OffensiveSkillType(SkillData skillData)
    {
        _skillData = skillData;
    }

    public void SetTarget(IFighterModel target)
    {
        _target = target;
        _affinity = GetAffinityFrom(_target);
    }

    public void ApplyEffect(Table table)
    {
        _attacker = table.GetGameState().CurrentFighter;
        double baseDamage = GetSkillDamage();
        _affinity.RecieveAttack(_target, baseDamage);
    }

    public IAffinityController GetAffinityFrom(IFighterModel target)
    {
        Affinities targetAffinities = target.GetState().Affinities;
        string affinityString = GetAffinityString(targetAffinities);
        IAffinityController affinity = AffinityFactory.FromString(affinityString);
        return affinity;
    }

    public ITypeView GetActionView()
    {
        int damageDone = _affinity.GetDamageDone();
        string affinityString = GetAffinityString(_target.GetState().Affinities);
        AttackView attackView = new AttackView(_skillData.Type, damageDone);
        attackView.SetAffinity(affinityString);
        attackView.SetActors(_attacker, _target);
        return attackView;
    }

    private double GetSkillDamage()
    {
        Stats attackerStats = _attacker.GetState().Stats;
        int stat = GetSkillStat(attackerStats);
        return Math.Sqrt(stat * _skillData.Power);
    }

    protected abstract string GetAffinityString(Affinities affinities);
    protected abstract int GetSkillStat(Stats stats);
}