using Shin_Megami_Tensei_View;
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
        _folder = new TeamsFolderController(teamsFolder);
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
        Table table = new Table(teams);
        BattleBackend backend = new BattleBackend(table, _view);
        backend.Play();
    }

    private TeamsFile ChooseTeamFromInput()
    {
        int teamNumber = ChooseTeamFile();
        TeamsFile file = _folder.ReadTeamFile(teamNumber);
        return file;
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