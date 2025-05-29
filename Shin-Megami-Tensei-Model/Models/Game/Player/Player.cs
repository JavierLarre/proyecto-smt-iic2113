namespace Shin_Megami_Tensei_Model;

public class Player: AbstractModel
{
    private readonly int _playerNumber;
    private readonly Team _team = new Team([], []);
    private int _usedSkillsCount;

    public static Player GetEmptyPlayer() => new Player();

    private Player() { }

    public Player(int playerNumber, Team team)
    {
        _playerNumber = playerNumber;
        _team = team;
    }

    public int GetPlayerNumber() => _playerNumber;
    public Team GetTeam() => _team;
    public void IncreaseUsedSkills() => _usedSkillsCount++;
    public int GetUsedSkillsCount() => _usedSkillsCount;

    public PlayerState GetPlayerState()
    {
        TeamState teamState = _team.GetTeamState();
        return new PlayerState
        {
            PlayerNumber = _playerNumber,
            Team = _team,
            UsedSkills = _usedSkillsCount,
            TeamState = teamState
        };
    }

}