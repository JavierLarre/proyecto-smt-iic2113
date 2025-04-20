namespace Shin_Megami_Tensei_Model;

public class Player
{
    public int PlayerNumber { get; }
    public Team Team { get; }

    private int _usedSkillsCount = 0;

    public Player(int playerNumber, Team team)
    {
        PlayerNumber = playerNumber;
        Team = team;
    }

    public void IncreaseUsedSkills() => _usedSkillsCount++;
    public int GetUsedSkillsCount() => _usedSkillsCount;
}