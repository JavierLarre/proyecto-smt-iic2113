using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei;

public class Game
{
    private View _view;
    private TeamsFolder _folder;
    private Team[] _teams;
    private BattleFrontend _frontend;
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _folder = new TeamsFolder(teamsFolder);
    }
    
    public void Play()
    {
        TeamsFile file = ChooseTeamFromInput();
        if (file.IsFileValid())
            Initialize(file.GetTeams());
        else
            _view.WriteLine("Archivo de equipos inválido");
        
    }

    private void Initialize(Team[] teams)
    {
        _frontend = new BattleFrontend(teams.First(), 1);
        Fight();
    }
    private void Fight()
    {

        _view.WriteLine(_frontend.PrintRound());
    }

    private TeamsFile ChooseTeamFromInput()
    {
        int teamNumber = GetInput();
        return _folder.ReadTeamFile(teamNumber);
    }

    private int GetInput()
    {
        string? input = null;
        while (input == null)
        {
            _view.WriteLine("Elige un archivo para cargar los equipos");
            _view.WriteLine(_folder.PrintFileNames());
            input = _view.ReadLine();
        }

        return int.Parse(input);
    }
}