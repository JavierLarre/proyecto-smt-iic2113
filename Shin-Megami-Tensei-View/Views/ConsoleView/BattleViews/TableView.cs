using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Battle;

public class TableView
{
    private readonly Table _table = Table.GetInstance();
    private readonly PlayerView _firstPlayer;
    private readonly PlayerView _secondPlayer;

    public TableView()
    {
        Player firstPlayer = _table.GetCurrentPlayer();
        Player secondPlayer = _table.GetEnemyPlayer();
        _firstPlayer = new PlayerView(firstPlayer);
        _secondPlayer = new PlayerView(secondPlayer);
    }
    public string GetCurrentPlayerTurns()
    {
        int fullTurns = _table.GetFullTurnsLeft();
        int blinkingTurns = _table.GetBlinkingTurnsLeft();
        return $"Full Turns: {fullTurns}"
               + '\n' + $"Blinking Turns: {blinkingTurns}";
    }

    public string GetCurrentInfo()
    {
        return $"{_firstPlayer.GetBanner()}\n{_secondPlayer.GetBanner()}";
    }

    public IFighterView GetFighterInTurn()
    {
        IFighter fighterInTurn = _table.GetCurrentFighter();
        return FighterViewFactory.FromFighter(fighterInTurn);
    }

    private PlayerView GetCurrentPlayer() =>
        new PlayerView(_table.GetCurrentPlayer());

    private PlayerView GetEnemyPlayer() =>
        new PlayerView(_table.GetEnemyPlayer());
}