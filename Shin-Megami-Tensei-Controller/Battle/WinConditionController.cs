using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei;

public class WinConditionController
{
    private Table _table;

    public WinConditionController(Table table)
    {
        _table = table;
    }

    public bool HasAnyTeamWon()
    {
        bool doesAnyTeamHaveBeenWipedOut = !DoBothTeamsHaveAlivePlayers();
        return doesAnyTeamHaveBeenWipedOut;
    }

    public Player GetWinner()
    {
        GameState gameState = GetGameState();
        bool enemyPlayerHasUnits = HasAliveUnits(gameState.EnemyTeam);
        Player currentPlayer = gameState.CurrentPlayer;
        Player enemyPlayer = gameState.EnemyPlayer;
        if (enemyPlayerHasUnits)
            return enemyPlayer;
        return currentPlayer;
    }

    private bool DoBothTeamsHaveAlivePlayers()
    {
        GameState gameState = GetGameState();
        Team currentTeam = gameState.CurrentTeam;
        Team enemyTeam = gameState.EnemyTeam;
        bool currentTeamHasAliveUnits = HasAliveUnits(currentTeam);
        bool enemyTeamHasAliveUnits = HasAliveUnits(enemyTeam);
        return currentTeamHasAliveUnits && enemyTeamHasAliveUnits;
    }

    private GameState GetGameState()
    {
        return _table.GetGameState();
    }

    private static bool HasAliveUnits(Team team)
    {
        TeamState state = team.GetTeamState();
        var aliveFighters = state.AliveFrontRow;
        bool hasAliveUnits = aliveFighters.Count != 0;
        return hasAliveUnits;
    }
}