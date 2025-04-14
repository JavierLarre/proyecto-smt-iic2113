namespace Shin_Megami_Tensei_Model;

public class Table
{
    public Player CurrentPlayer { get; private set; }
    public Player EnemyPlayer { get; private set; }

    public Table(IEnumerable<Team> teams)
    {
        var players = teams.Select((team, i) => new Player(i, team)).ToList();
        CurrentPlayer = players[0];
        EnemyPlayer = players[1];
    }

    public void SwapPlayers()
    {
        (CurrentPlayer, EnemyPlayer) = (EnemyPlayer, CurrentPlayer);
    }

    public int GetFullTurnsLeftFromCurrentPlayer()
    {
        return CurrentPlayer.GetFullTurnsLeft();
    }

    public int GetBlinkingTurnsLeftFromCurrentPlayer()
    {
        return CurrentPlayer.GetBlinkingTurnsLeft();
    }

    public IEnumerable<IFighter> GetCurrentFighters()
    {
        return CurrentPlayer.Team.GetFrontRow();
    }

    public IFighter GetCurrentFighter()
    {
        return GetCurrentPlayerFightOrder().First();
    }

    public IEnumerable<IFighter> GetCurrentPlayerFightOrder()
    {
        return CurrentPlayer.GetFightOrder();
    }

    public IEnumerable<IFighter> GetEnemyTeamTargets()
    {
        return EnemyPlayer.Team.GetAliveFront();
    }

    public void EndTurn()
    {
        CurrentPlayer.Team.EndTurn();
    }
}