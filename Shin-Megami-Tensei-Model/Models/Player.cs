namespace Shin_Megami_Tensei_Model;

public class Player
{
    public int PlayerNumber { get; }
    public Team Team { get; }

    public Player(int playerNumber, Team team)
    {
        PlayerNumber = playerNumber;
        Team = team;
    }

    public int GetFullTurnsLeft() => Team.GetFullTurnsLeft();
    public int GetBlinkingTurnsLeft() => Team.GetBlinkingTurnsLeft();
    public IEnumerable<IFighter> GetFightOrder() => Team.GetFightOrder();
}