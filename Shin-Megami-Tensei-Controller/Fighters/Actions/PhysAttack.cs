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

    public abstract string ActionName();
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
        IFighter attacker = table.GetCurrentFighter();
        TableView tableView = new TableView(table);
        IOptionMenu targetMenu = OptionFactory.BuildMenu(
            $"Seleccione un objetivo para {attacker.Name}",
            "",
            "-",
            tableView.GetEnemyTeamTargets(),
            view,
            true
        );
        var targets = table.GetEnemyTeamTargets().Zip(tableView.GetEnemyTeamTargets()).ToDictionary(tuple => tuple.Second, tuple => tuple.First);
        string target = targetMenu.GetOption().ToString();
        if (target == "Cancelar")
            throw new ActionException();
        return targets[target];
    }
}