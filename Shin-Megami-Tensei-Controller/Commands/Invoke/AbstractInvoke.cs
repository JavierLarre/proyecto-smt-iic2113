using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Actions;

public abstract class AbstractInvoke: IFighterCommand
{
    
    public void Execute(Table table)
    {
        var summonController = new SummonController(table);
        summonController.AskUserForTarget();
        int atPosition = GetSummonPosition(table);
        summonController.SummonAt(atPosition);
        TurnsModel turnsModel = table.GetGameState().TurnsModel;
        ConsumeTurns(turnsModel);
    }

    private static void ConsumeTurns(TurnsModel turnsModel)
    {
        turnsModel.ConsumeAndGainTurn();
    }

    protected abstract int GetSummonPosition(Table table);

}