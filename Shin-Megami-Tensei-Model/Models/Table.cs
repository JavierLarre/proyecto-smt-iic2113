namespace Shin_Megami_Tensei_Model;

public class Table
{
    private Player _currentPlayer;
    private Player _enemyPlayer;

    public Table(IEnumerable<Team> teams)
    {
        List<Player> players = teams
            .Select((team, i) => new Player(i, team))
            .ToList();
        _currentPlayer = players[0];
        _enemyPlayer = players[1];
    }

    public Player GetCurrentPlayer() => _currentPlayer;
    public Player GetEnemyPlayer() => _enemyPlayer;

    public int GetFullTurnsLeftFromCurrentPlayer()
    {
        return _currentPlayer.Team.GetFullTurnsLeft();
    }

    public int GetBlinkingTurnsLeftFromCurrentPlayer()
    {
        return _currentPlayer.Team.GetBlinkingTurnsLeft();
    }

    public IFighter GetFighterInTurn()
    {
        return GetCurrentPlayerFightOrder().First();
    }

    public IEnumerable<IFighter> GetCurrentPlayerFightOrder()
    {
        return _currentPlayer.Team.GetFightOrder();
    }

    public IEnumerable<IFighter> GetEnemyTeamAliveTargets()
    {
        return _enemyPlayer.Team.GetAliveFront();
    }

    public bool HasAnyTeamLost()
    {
        var currentAliveUnits = _currentPlayer.Team.GetAliveFront();
        var enemyAliveUnits = _enemyPlayer.Team.GetAliveFront();
        return !(currentAliveUnits.Any() && enemyAliveUnits.Any());
    }

    public void EndTurn()
    {
        _currentPlayer.Team.ConsumeTurn();
    }

    public void EndRound()
    {
        SwapPlayers();
        _currentPlayer.Team.ResetTurns();
    }

    private void SwapPlayers()
    {
        (_currentPlayer, _enemyPlayer) = (_enemyPlayer, _currentPlayer);
    }
}