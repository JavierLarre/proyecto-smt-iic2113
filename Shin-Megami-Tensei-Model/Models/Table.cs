namespace Shin_Megami_Tensei_Model;

public class Table
{
    private Player _currentPlayer = null!;
    private Player _enemyPlayer = null!;

    private Table()
    {
    }

    private static readonly Table Singleton = new Table();
    public static Table GetInstance() => Singleton;
    // Dos críticas de singleton
    // ahora el proyecto depende de este modelo
    // Y agrega una responsabilidad a Table (ergo, rompe SRP)

    public void SetPlayersFromTeams(IEnumerable<Team> teams)
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
        return _currentPlayer.GetTeam().GetFullTurnsLeft();
    }

    public int GetBlinkingTurnsLeftFromCurrentPlayer()
    {
        return _currentPlayer.GetTeam().GetBlinkingTurnsLeft();
    }

    public void IncreaseCurrentPlayerUsedSkillsCount()
    {
        _currentPlayer.IncreaseUsedSkills();
    }

    public int GetCurrentPlayerUsedSkillsCount()
    {
        return _currentPlayer.GetUsedSkillsCount();
    }

    public IFighter GetCurrentFighter()
    {
        return GetCurrentPlayerFightOrder().First();
    }

    public IEnumerable<IFighter> GetCurrentPlayerFightOrder()
    {
        return _currentPlayer.GetTeam().GetFightOrder();
    }

    public IEnumerable<IFighter> GetEnemyTeamAliveTargets()
    {
        return _enemyPlayer.GetTeam().GetAliveFront();
    }

    public bool HasAnyTeamLost()
    {
        var currentAliveUnits = _currentPlayer.GetTeam().GetAliveFront();
        var enemyAliveUnits = _enemyPlayer.GetTeam().GetAliveFront();
        return !(currentAliveUnits.Any() && enemyAliveUnits.Any());
    }

    public void EndTurn()
    {
        _currentPlayer.GetTeam().ConsumeTurn();
    }

    public void EndRound()
    {
        SwapPlayers();
        _currentPlayer.GetTeam().ResetTurns();
    }

    private void SwapPlayers()
    {
        (_currentPlayer, _enemyPlayer) = (_enemyPlayer, _currentPlayer);
    }
}