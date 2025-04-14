using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Battle;

public class TeamView
{
    private Team _team;
    private IFighterView _leader;
    private const string Positions = "ABCDEFGHI";
    public TeamView(Team team)
    {
        _team = team;
        _leader = FighterViewFactory.FromFighter(_team.GetLeader());
    }

    public string GetLeaderName() => _leader.GetFighterName();

    public string GetFightersInfo()
    {
        var fighterViews = GetFrontRow().ToArray();
        string[] fightersInfo = new string[Constants.MaxSizeFrontRow];
        for (int i = 0; i < Constants.MaxSizeFrontRow; i++)
        {
            if (i < fighterViews.Length)
            {
                fightersInfo[i] = GetFighterPosition(fighterViews[i], i);
            }
            else
            {
                fightersInfo[i] = GetFighterPosition(null, i);
            }
        }
        return string.Join('\n', fightersInfo);
    }


    private IEnumerable<IFighterView> GetFrontRow() =>
        _team.GetFrontRow().Select(FighterViewFactory.FromFighter);

    private string GetFighterPosition(IFighterView? fighter, int position)
    {
        string fighterInfo = fighter is null ? "" : fighter.GetFighterInfo();
        return $"{Positions[position]}-{fighterInfo}";
    }
}