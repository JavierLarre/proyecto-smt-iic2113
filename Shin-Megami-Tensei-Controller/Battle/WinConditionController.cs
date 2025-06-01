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
        bool enemyPlayerHasUnits = HasAliveUnits(gameState.EnemyPlayerState);
        Player currentPlayer = gameState.CurrentPlayer;
        Player enemyPlayer = gameState.EnemyPlayer;
        if (enemyPlayerHasUnits)
            return enemyPlayer;
        return currentPlayer;
    }

    private bool DoBothTeamsHaveAlivePlayers()
    {
        GameState gameState = GetGameState();
        bool currentTeamHasAliveUnits = HasAliveUnits(gameState.CurrentPlayerState);
        bool enemyTeamHasAliveUnits = HasAliveUnits(gameState.EnemyPlayerState);
        return currentTeamHasAliveUnits && enemyTeamHasAliveUnits;
    }

    private GameState GetGameState()
    {
        return _table.GetGameState();
    }

    private static bool HasAliveUnits(PlayerState playerState)
    {
        TeamState teamState = playerState.TeamState;
        var aliveFighters = teamState.AliveTargets;
        bool hasAliveUnits = aliveFighters.Count != 0;
        return hasAliveUnits;
    }
}