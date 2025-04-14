using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei;

public class Game: IController
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
        ICollection<Team> teams;
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

    private void StartFight(ICollection<Team> teams)
    {
        Table table = new Table(teams);
        BattleController controller = new BattleController(table, _view);
        controller.Play();
    }
}