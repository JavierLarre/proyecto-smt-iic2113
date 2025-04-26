using Shin_Megami_Tensei_Model.TeamServices;

namespace Shin_Megami_Tensei_Model;

public class Player
{
    private readonly int _playerNumber;
    private readonly Team _team;
    private int _usedSkillsCount = 0;

    public Player(int playerNumber, Team team)
    {
        _playerNumber = playerNumber;
        _team = team;
    }

    public int GetPlayerNumber() => _playerNumber;
    public Team GetTeam() => _team;
    public void IncreaseUsedSkills() => _usedSkillsCount++;
    public int GetUsedSkillsCount() => _usedSkillsCount;
    public void SetTeamToService(ITeamService service)
    {
        service.SetTeam(_team);
    }
}