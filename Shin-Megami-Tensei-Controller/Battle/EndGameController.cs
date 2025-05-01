using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;

namespace Shin_Megami_Tensei.Battles;

public class EndGameController
{
    public void EndGame()
    {
        Player winner = GetWinner();
        WinnerView winnerView = new WinnerView(winner);
        winnerView.Display();
    }

    private Player GetWinner()
    {
        Table table = Table.GetInstance();
        return table.GetWinner();
    }
}