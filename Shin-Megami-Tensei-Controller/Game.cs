using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei;

public class Game
{
    private readonly View _view;
    private readonly TeamsFolderController _folder;
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _folder = new TeamsFolderController(teamsFolder, view);
    }
    
    public void Play()
    {
        IEnumerable<Team> teams;
        try
        {
            teams = _folder.GetTeams();
        }
        catch (ArgumentException e)
        {
            _view.WriteLine(e.Message);
            return;
        }
        StartFight(teams);
    }

    private void StartFight(IEnumerable<Team> teams)
    {
        Table table = GetTableFromTeams(teams);
        BattleViewSingleton.SetBattleView(_view);
        BattleController controller = new BattleController(table);
        controller.Play();
    }

    private Table GetTableFromTeams(IEnumerable<Team> teams)
    {
        List<Player> players = teams
                    .Select((team, i) => new Player(i, team))
                    .ToList();
        Player player1 = players[0];
        Player player2 = players[1];
        Table table = new Table(player1, player2);
        return table;
    }
}