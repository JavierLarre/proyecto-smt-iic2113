using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei;

public class Game
{
    private View _view;
    private TeamsFolder _folder;
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _folder = new TeamsFolder(teamsFolder);
    }
    
    public void Play()
    {
        TeamsFile file = ChooseTeamFromInput();
        if (file.IsFileValid())
            StartFight(file.GetTeams());
        else
            _view.WriteLine("Archivo de equipos inválido");
        
    }

    private void StartFight(Team[] teams)
    {
        BattleBackend backend = new BattleBackend(teams, _view);
        backend.Play();
    }

    private TeamsFile ChooseTeamFromInput()
    {
        int teamNumber = ChooseTeamFile();
        return _folder.ReadTeamFile(teamNumber);
    }

    private int ChooseTeamFile()
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