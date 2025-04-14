
using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Teams;

public class TeamController
{
    private const int MaxActiveFighters = 4;
    private Team _team;

    public TeamController(Team team)
    {
        _team = team;
    }
}