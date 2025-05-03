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

    private IFighter GetTarget()
    {
        var reserve = GetAliveReserve();
        SummonFighterMenu summonMenu = new SummonFighterMenu(reserve);
        IFighter target = summonMenu.GetTarget();
        return target;
    }

    private IEnumerable<IFighter> GetAliveReserve()
    {
        var reserve = _table.GetCurrentPlayer().GetTeam().GetReserve()
            .Where(fighter => fighter.IsAlive());
        return reserve;
    }

    private void Summon(IFighter target)
    {
        int atPosition = GetSummonPosition();
        _table.Summon(target, atPosition);
    }

    private void ConsumeTurns()
    {
        TurnManager turnManager = _table.GetTurnManager();
        turnManager.ConsumeAndGainTurn();
    }

    private void Display(IFighter summoned)
    {
        SummonView summonView = new SummonView(summoned);
        summonView.Display();
    }

    protected abstract int GetSummonPosition();

}