using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei;

public class Game
{
    private View View;
    private TeamsFolder Folder;
    private Team[] Teams;
    public Game(View view, string teamsFolder)
    {
        View = view;
        Folder = new TeamsFolder(teamsFolder);
    }
    
    public void Play()
    {
        TeamsFile file = ChooseTeamFromInput();
        if (file.IsFileValid())
            Teams = file.GetTeams();
        else
            View.WriteLine("Archivo de equipos inválido");
        
    }

    private TeamsFile ChooseTeamFromInput()
    {
        int teamNumber = GetInput();
        return Folder.ReadTeamFile(teamNumber);
    }

    private int GetInput()
    {
        string? input = null;
        while (input == null)
        {
            View.WriteLine("Elige un archivo para cargar los equipos");
            View.WriteLine(Folder.PrintFileNames());
            input = View.ReadLine();
        }

        return int.Parse(input);
    }
}