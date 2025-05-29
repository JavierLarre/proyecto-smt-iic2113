using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Battle;

public class TeamView
{
    private Team _team;
    private FighterView _leader;
    private const string Positions = "ABCD";
    public TeamView(Team team)
    {
        _team = team;
        _leader = new FighterView(_team.GetTeamState().Leader);
    }

    public string GetLeaderName() => _leader.GetName();

    public string GetFightersInfo()
    {
        var fighterViews = GetFrontRow();
        var fightersInfo = fighterViews.Select(GetFighterPosition);
        return string.Join('\n', fightersInfo);
    }


    private IEnumerable<FighterView> GetFrontRow() =>
        _team.GetFrontRow().Select(fighter => new FighterView(fighter));

    private string GetFighterPosition(FighterView fighter, int position)
    {
        string fighterInfo = fighter.GetInfo();
        return $"{Positions[position]}-{fighterInfo}";
    }
}