using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei.Fighters.Actions;

public abstract class AbstractInvoke: IFighterCommand
{
    private Table _table = Table.GetInstance();
    
    public void Execute()
    {
        var summonController = new SummonController(_table);
        summonController.AskUserForTarget();
        int atPosition = GetSummonPosition();
        summonController.SummonAt(atPosition);
        ConsumeTurns();
    }

    private void ConsumeTurns()
    {
        TurnsModel turnManager = _table.GetTurnManager();
        turnManager.ConsumeAndGainTurn();
    }

    protected abstract int GetSummonPosition();

}