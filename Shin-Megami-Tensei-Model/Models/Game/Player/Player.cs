namespace Shin_Megami_Tensei_Model;

public class Player: AbstractModel
{
    private readonly int _playerNumber;
    private readonly Team _team;
    private int _usedSkillsCount;
    
    public Player(int playerNumber, Team team)
    {
        _playerNumber = playerNumber;
        _team = team;
    }

    public void IncreaseUsedSkills() => _usedSkillsCount++;

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