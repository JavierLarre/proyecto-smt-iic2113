using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;

namespace Shin_Megami_Tensei.Battles;

public class RoundController
{
    private Table _table;
    private TurnController _turnController;
    private WinConditionController _winCondition;

    public RoundController(Table table)
    {
        _table = table;
        _turnController = new TurnController(_table);
        _winCondition = new WinConditionController(_table);
    }
    
    public void PlayRound()
    {
        DisplayRoundStart();
        while (!IsRoundDone())
            _turnController.PlayTurn();
        if (!_winCondition.HasAnyTeamWon())
            _table.EndRound();
    }

    private void DisplayRoundStart()
    {
        Player currentPlayer = _table.GetGameState().CurrentPlayer;
        StartRoundView roundView = new StartRoundView(currentPlayer);
        roundView.Display();
    }

    private bool IsRoundDone()
    {
        return _winCondition.HasAnyTeamWon() || IsPlayerOutOfTurns();
    }

    private bool IsPlayerOutOfTurns()
    {
        TurnsData turns = _table.GetGameState().TurnsData;
        int fullTurns = turns.FullTurns;
        int blinkingTurns = turns.BlinkingTurns;
        return fullTurns == 0 && blinkingTurns == 0;
    }

}