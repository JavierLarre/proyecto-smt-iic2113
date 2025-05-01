using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;

namespace Shin_Megami_Tensei.Battles;

public class RoundController
{
    private Table _table = Table.GetInstance();
    private TurnController _turnController = new();
    private TurnManager _turnManager;

    public RoundController()
    {
        _turnManager = _table.GetTurnManager();
    }
    
    public void PlayRound()
    {
        DisplayRoundStart();
        while (!IsRoundDone())
            _turnController.PlayTurn();
        _table.EndRound();
    }

    private void DisplayRoundStart()
    {
        Player currentPlayer = _table.GetCurrentPlayer();
        StartRoundView roundView = new StartRoundView(currentPlayer);
        roundView.Display();
    }

    private bool IsRoundDone()
    {
        return _table.HasAnyTeamLost() || IsPlayerOutOfTurns();
    }

    private bool IsPlayerOutOfTurns()
    {
        Turns turns = _turnManager.GetTurns();
        int fullTurns = turns.FullTurns;
        int blinkingTurns = turns.BlinkingTurns;
        return fullTurns == 0 && blinkingTurns == 0;
    }

}