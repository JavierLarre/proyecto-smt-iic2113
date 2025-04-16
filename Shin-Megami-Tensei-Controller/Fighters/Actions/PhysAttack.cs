using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Fighters.Actions;

public abstract class PhysAttack: IAction
{
    private bool _isDone = false;
    private const double PhysicalDamageMultiplier = 0.0114;

    public abstract string GetActionName();
    public bool IsDone() => _isDone;
    protected abstract int Modifier();
    protected abstract int FighterStat();
    protected abstract void PrintAttack(BattleView view, IFighter reciever);
    protected int CalculateDamage() =>
        (int)Math.Floor(FighterStat() * Modifier() * PhysicalDamageMultiplier);
    
    public void Reset() => _isDone = false;

    public void Act(Table table, BattleView view)
    {
        IFighter target = GetTargetFromUser(table, view);
        int damage = CalculateDamage();
        target.RecieveDamage(damage);
        PrintAttack(view, target);
        _isDone = true;
    }

    private IFighter GetTargetFromUser(Table table, BattleView view)
    {
        string targetName;
        try
        {
            targetName = view.GetTargetFromUser();
        }
        catch (OptionException e)
        {
            throw new ActionException();
        }
        var targets = table.GetEnemyTeamAliveTargets();
        return targets.First(target => target.Name == targetName);
    }
}