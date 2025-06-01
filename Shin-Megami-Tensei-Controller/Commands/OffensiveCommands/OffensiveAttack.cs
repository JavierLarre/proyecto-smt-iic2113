using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Fighters;
using Shin_Megami_Tensei_View.Views;
using Shin_Megami_Tensei.TargetTypes;

namespace Shin_Megami_Tensei.Fighters.Actions;

public abstract class OffensiveAttack: IFighterCommand
{
    private const double PhysicalDamageMultiplier = 0.0114;
    
    private Table _table;
    private IFighterModel _attacker;
    private IFighterModel _target = new EmptyFighter();
    private IAffinityController _affinity = new NeutralAffinity();

    protected OffensiveAttack(Table table)
    {
        _table = table;
        _attacker = _table.GetGameState().CurrentFighter;
    }

    public void Execute()
    {
        _target = GetTargetFromUser();
        _affinity = AffinityFactory.FromString(GetAffinityString());
        ApplyAttack();
        DisplayAttack();
    }

    private void DisplayAttack()
    {
        string affinityString = GetAffinityString();
        int damageDone = _affinity.GetDamageDone();
        string attackType = GetAttackType();
        AttackView attackView = new AttackView(attackType, damageDone);
        attackView.SetActors(_attacker, _target);
        attackView.SetAffinity(affinityString);
        attackView.StartDisplay();
        attackView.Display();
        attackView.DisplayEnding();
    }

    private void ApplyAttack()
    {
        double damage = CalculateDamage();
        _affinity.RecieveAttack(_target, damage);
        _affinity.ConsumeTurns();
    }

    
    private double CalculateDamage()
    {
        Stats attackerStats = _attacker.GetState().Stats;
        int stat = GetStat(attackerStats);
        double damage = stat * GetModifier() * PhysicalDamageMultiplier;
        return damage;
    }

    private IFighterModel GetTargetFromUser()
    {
        SingleEnemyTarget targetController = new SingleEnemyTarget(_table);
        return targetController.GetTarget();
    }

    private string GetAffinityString()
    {
        return GetAffinityString(_target.GetState().Affinities);
    }

    protected abstract string GetAttackType();
    protected abstract int GetModifier();
    protected abstract int GetStat(Stats stats);
    protected abstract string GetAffinityString(Affinities affinities);
}