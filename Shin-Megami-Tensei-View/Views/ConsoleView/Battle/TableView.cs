using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Battle;

public class TableView
{
    private Table _table;

    public TableView(Table table)
    {
        _table = table;
    }

    public int GetCurrentPlayerNumber() => GetCurrentPlayer().GetPlayerNumber();
    public string GetCurrentPlayerName() => GetCurrentPlayer().GetPlayerName();

    public string GetCurrentPlayerTurns()
    {
        int fullTurns = _table.GetFullTurnsLeftFromCurrentPlayer();
        int blinkingTurns = _table.GetBlinkingTurnsLeftFromCurrentPlayer();
        return $"Full Turns: {fullTurns}"
               + '\n' + $"Blinking Turns: {blinkingTurns}";
    }

    public string GetCurrentInfo()
    {
        PlayerView current = GetCurrentPlayer();
        PlayerView enemy = GetEnemyPlayer();
        if (current.GetPlayerNumber() == 2)
            (current, enemy) = (enemy, current);
        return $"{current.GetBanner()}\n{enemy.GetBanner()}";
    }

    public string GetCurrentPlayerFightOrder()
    {
        var orderedFighters = _table.GetCurrentPlayerFightOrder();
        var stringfiedFighters = orderedFighters
            .Select((fighter, i) => $"{i + 1}-{fighter.Name}");
        return string.Join('\n', stringfiedFighters);
    }

    public IEnumerable<IFighterView> GetEnemyTeamTargets()
    {
        var targets = _table.GetEnemyTeamAliveTargets()
            .Select(FighterViewFactory.FromFighter);
        return targets;
    }

    public string GetWinner()
    {
        PlayerView enemy = GetEnemyPlayer();
        return $"Ganador: {enemy.GetPlayerName()} (J{enemy.GetPlayerNumber()})";
    }

    public IFighterView GetFighterInTurn()
    {
        IFighter fighterInTurn = _table.GetFighterInTurn();
        return FighterViewFactory.FromFighter(fighterInTurn);
    }

    private PlayerView GetCurrentPlayer() =>
        new PlayerView(_table.GetCurrentPlayer());

    private PlayerView GetEnemyPlayer() =>
        new PlayerView(_table.GetEnemyPlayer());
}