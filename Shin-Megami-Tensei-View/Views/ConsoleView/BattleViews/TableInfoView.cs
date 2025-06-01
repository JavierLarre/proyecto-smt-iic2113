using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Battle;

public class TableInfoView: IView
{
    private readonly PlayerView _firstPlayer;
    private readonly PlayerView _secondPlayer;

    public TableInfoView(GameState gameState)
    {
        Player firstPlayer = gameState.CurrentPlayer;
        Player secondPlayer = gameState.EnemyPlayer;
        if (firstPlayer.GetPlayerState().PlayerNumber != 0)
            (firstPlayer, secondPlayer) = (secondPlayer, firstPlayer);
        _firstPlayer = new PlayerView(firstPlayer);
        _secondPlayer = new PlayerView(secondPlayer);
    }

    public void Display()
    {
        ConsoleBattleView view = BattleViewSingleton.GetBattleView();
        view.DisplayIndent();
        _firstPlayer.Display();
        _secondPlayer.Display();
    }
}