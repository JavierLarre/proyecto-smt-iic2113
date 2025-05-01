using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;

public class WinnerView: IView
{
    private Player _winner;

    public WinnerView(Player winner) => _winner = winner;

    public void Display()
    {
        ConsoleBattleView view = BattleViewSingleton.GetBattleView();
        view.DisplayCard(GetFormattedWinner());
    }

    private string GetFormattedWinner()
    {
        PlayerView winnerView = new PlayerView(_winner);
        return $"Ganador: {winnerView.GetPlayerNameAndNumber()}";
    }
}