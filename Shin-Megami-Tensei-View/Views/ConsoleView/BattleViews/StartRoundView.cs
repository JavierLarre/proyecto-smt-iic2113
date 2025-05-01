using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;

public class StartRoundView: IView
{
    private Player _currentPlayer;

    public StartRoundView(Player currentPlayer)
    {
        _currentPlayer = currentPlayer;
    }

    public void Display()
    {
        BattleView view = BattleViewSingleton.GetBattleView();
        PlayerView currentPlayerView = new PlayerView(_currentPlayer);
        view.DisplayCard($"Ronda de {currentPlayerView.GetPlayerNameAndNumber()}");
    }
}