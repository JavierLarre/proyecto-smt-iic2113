using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Fighters;
using Shin_Megami_Tensei_View.Views;
using Shin_Megami_Tensei.TargetTypes;

namespace Shin_Megami_Tensei.Fighters.Actions;

public abstract class OffensiveAttack: IFighterCommand
{
    private const double PhysicalDamageMultiplier = 0.0114;
    
    private Table _table = null!;
    private IFighterModel _attacker = new EmptyFighter();
    private IFighterModel _target = new EmptyFighter();
    private IAffinityController _affinity = new NeutralAffinity();

    public void Execute(Table table)
    {
        _table = table;
        _attacker = _table.GetGameState().CurrentFighter;
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
        TurnsModel turnsModel = _table.GetGameState().TurnsModel;
        _affinity.SetTarget(_target);
        _affinity.SetDamage(damage);
        _affinity.RecieveAttack(_table);
        _affinity.ConsumeTurns(turnsModel);
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
        var controllerBuilder = new SingleFighterMenuControllerBuilder(_table);
        var targetController = controllerBuilder.BuildFromAliveEnemyTeam();
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