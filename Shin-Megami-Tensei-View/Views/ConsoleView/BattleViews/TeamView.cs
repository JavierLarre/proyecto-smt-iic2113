using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Battle;

public class TeamView //todo: cambiarlo a Iview
{
    private Team _team;
    private IFighterView _leader;
    private const string Positions = "ABCD";
    public TeamView(Team team)
    {
        _team = team;
        _leader = FighterViewFactory.FromFighter(_team.GetTeamState().Leader);
    }

    public string GetLeaderName() => _leader.GetName();

    public string GetFightersInfo()
    {
        var fighterViews = GetFrontRow();
        var fightersInfo = fighterViews.Select(GetFighterPosition);
        return string.Join('\n', fightersInfo);
    }


    private IEnumerable<IFighterView> GetFrontRow() =>
        _team.GetTeamState().FrontRow.Select(FighterViewFactory.FromFighter);

    private string GetFighterPosition(IFighterView fighter, int position)
    {
        string fighterInfo = fighter.GetInfo();
        return $"{Positions[position]}-{fighterInfo}";
    }
}