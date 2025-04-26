namespace Shin_Megami_Tensei_Model.TeamServices;

public class FrontRowService: ITeamService
{
    private Team _team;
    
    public void SetTeam(Team team)
    {
        _team = team;
    }

    public IEnumerable<IFighter> GetFrontRow()
    {
        return _team.GetFrontRow();
    }
}