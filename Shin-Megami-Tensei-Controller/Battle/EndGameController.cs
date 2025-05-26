using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;

namespace Shin_Megami_Tensei.Battles;

public class EndGameController
{
    private WinConditionController _winCondition;
    public EndGameController(Table table)
    {
        _winCondition = new WinConditionController(table);
    }
    public void EndGame()
    {
        Player winner = _winCondition.GetWinner();
        WinnerView winnerView = new WinnerView(winner);
        winnerView.Display();
    }
}