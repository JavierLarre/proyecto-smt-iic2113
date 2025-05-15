using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Actions;

public abstract class AttackCommand: IFighterCommand
{
    private const double PhysicalDamageMultiplier = 0.0114;
    
    protected Table Table = Table.GetInstance();
    protected ConsoleBattleView View = BattleViewSingleton.GetBattleView();

    public void Execute()
    {
        IFighterModel reciever = GetTargetFromUser();
        var affinity = GetAffinityController(reciever);
        double damage = CalculateDamage();
        affinity.RecieveAttack(reciever, damage);
        affinity.ConsumeTurns();
        View.DisplayCard(GetEffectString(reciever));
    }

    private string GetEffectString(IFighterModel target)
    {
        string attack = GetAttackString(target);
        IAffinityController affinity = GetAffinityController(target);
        string effectsResult = affinity.GetEffectString(target, CalculateDamage());
        return attack + '\n' + effectsResult + '\n' + GetRecieverEndedWith(target);
    }

    private string GetRecieverEndedWith(IFighterModel target)
    {
        IFighterModel reciever;
        reciever = GetAffinityController(target) is RepelAffinity ? 
            GetAttacker() : 
            target;
        return FighterViewFactory.FromFighter(reciever).GetHpEndedWith();
    }

    protected abstract int Modifier();
    protected abstract int FighterStat();
    protected abstract string GetAttackString(IFighterModel reciever);
    protected abstract string GetAffinityString(IFighterModel target);

    private IAffinityController GetAffinityController(IFighterModel target)
    {
        string affinity = GetAffinityString(target);
        AffinityFactory factory = new AffinityFactory(affinity);
        return factory.GetAffinity();
    }

    protected IFighterModel GetAttacker() => Table.GetCurrentFighter();

    protected double CalculateDamage()
    {
        double damage = FighterStat() * Modifier() * PhysicalDamageMultiplier;
        return damage;
    }

    private IFighterModel GetTargetFromUser()
    {
        var targets = Table.GetEnemyTeamAliveTargets().ToList();
        try
        {
            IOptionMenu targetMenu = new TargetMenu(GetAttacker(), targets);
            string targetName = targetMenu.GetChoice();
            return targets.First(target => target.GetUnitData().Name == targetName);
        }
        catch (OptionException e)
        {
            throw new FighterCommandException();
        }
    }
}