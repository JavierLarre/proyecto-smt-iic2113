using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Actions;

public abstract class PhysAttack: IFighterCommand
{
    protected Table Table;
    protected BattleView View;
    protected IFighter Attacker;
    protected IFighter Reciever;

    protected PhysAttack(Table table, BattleView view)
    {
        Table = table;
        View = view;
        Attacker = Table.GetFighterInTurn();
    }
    
    private const double PhysicalDamageMultiplier = 0.0114;

    protected abstract int Modifier();
    protected abstract int FighterStat();
    protected abstract void PrintAttack();
    protected int CalculateDamage() =>
        (int)Math.Floor(FighterStat() * Modifier() * PhysicalDamageMultiplier);

    public void Execute()
    {
        Reciever = GetTargetFromUser();
        int damage = CalculateDamage();
        Reciever.RecieveDamage(damage);
        PrintAttack();
    }

    private IFighter GetTargetFromUser()
    {
        string targetName;
        try
        {
            targetName = View.GetTargetFromUser();
        }
        catch (OptionException e)
        {
            throw new FighterCommandException();
        }
        var targets = Table.GetEnemyTeamAliveTargets();
        return targets.First(target => target.Name == targetName);
    }
}