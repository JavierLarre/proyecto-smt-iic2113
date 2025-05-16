using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei.Fighters.Actions;

public abstract class AbstractInvoke: IFighterCommand
{
    private Table _table = Table.GetInstance();
    
    public void Execute()
    {
        var target = GetTarget();
        Summon(target);
        ConsumeTurns();
        Display(target);
    }

    private IFighterModel GetTarget()
    {
        var reserve = GetAliveReserve();
        SummonFighterMenu summonMenu = new SummonFighterMenu(reserve);
        IFighterModel target = summonMenu.GetTarget();
        return target;
    }

    private IEnumerable<IFighterModel> GetAliveReserve()
    {
        Team currentTeam = _table.GetCurrentPlayer().GetTeam();
        var reserve = currentTeam.GetReserve();
        return reserve.Where(fighter => fighter.IsAlive());
    }

    private void Summon(IFighterModel target)
    {
        int atPosition = GetSummonPosition();
        _table.Summon(target, atPosition);
    }

    private void ConsumeTurns()
    {
        TurnsModel turnManager = _table.GetTurnManager();
        turnManager.ConsumeAndGainTurn();
    }

    private void Display(IFighterModel summoned)
    {
        SummonView summonView = new SummonView(summoned);
        summonView.Display();
    }

    protected abstract int GetSummonPosition();

}