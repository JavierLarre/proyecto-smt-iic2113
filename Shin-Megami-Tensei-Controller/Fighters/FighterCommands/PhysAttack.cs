using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Actions;

public abstract class PhysAttack: IFighterCommand
{
    protected IFighter Attacker;

    protected PhysAttack(IFighter attacker)
    {
        Attacker = attacker;
    }

    public void Execute(Table table, BattleView view)
    {
        IFighter reciever = GetTargetFromUser(table, view);
        int damage = CalculateDamage();
        reciever.RecieveDamage(damage);
        PrintAttack(reciever, view);
    }
    
    private const double PhysicalDamageMultiplier = 0.0114;

    protected abstract int Modifier();
    protected abstract int FighterStat();
    protected abstract void PrintAttack(IFighter reciever, BattleView view);
    protected int CalculateDamage() =>
        (int)Math.Floor(FighterStat() * Modifier() * PhysicalDamageMultiplier);

    private IFighter GetTargetFromUser(Table table, BattleView view)
    {
        var targets = table.GetEnemyTeamAliveTargets().ToList();
        try
        {
            IOptionMenu targetMenu = new TargetMenu(Attacker, targets);
            string targetName = view.GetChoiceFromOptionMenu(targetMenu);
            return targets.First(target => target.Name == targetName);
        }
        catch (OptionException e)
        {
            throw new FighterCommandException();
        }
    }
}