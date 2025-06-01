using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class DemonInvoke: AbstractInvoke
{

    protected override int GetSummonPosition(Table table)
    {
        GameState gameState = table.GetGameState();
        IFighterModel currentDemon = gameState.CurrentFighter;
        List<IFighterModel> frontRow = gameState
            .CurrentPlayerState
            .TeamState
            .FrontRow
            .ToList();
        int atPosition = frontRow.IndexOf(currentDemon);
        return atPosition;
    }
}