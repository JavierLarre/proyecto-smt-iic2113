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
        if (current.GetPlayerNumber() == 1)
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

    public IEnumerable<string> GetEnemyTeamTargets()
    {
        var targets = _table.GetEnemyTeamTargets()
            .Select(FighterViewFactory.FromFighter);
        return targets.Select(target => target.GetFighterInfo());
    }

    public string GetWinner()
    {
        PlayerView enemy = GetEnemyPlayer();
        return $"Ganador: {enemy.GetPlayerName()} (J{enemy.GetPlayerNumber()+1})";
    }

    private PlayerView GetCurrentPlayer() =>
        new PlayerView(_table.CurrentPlayer);

    private PlayerView GetEnemyPlayer() =>
        new PlayerView(_table.EnemyPlayer);
}