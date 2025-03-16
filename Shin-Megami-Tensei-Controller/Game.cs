using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei;

public class Game
{
    private TeamFiles TeamFiles;
    private Team[] Teams;
    public Game(View view, string teamsFolder)
    {
        TeamFiles = new TeamFiles(teamsFolder);
    }
    
    public void Play()
    {
        ChooseTeam();
    }

    private void ChooseTeam()
    {
        Console.WriteLine("Elige un archivo para cargar los equipos");
        Console.WriteLine(TeamFiles.TeamNames());
        string? input = Console.ReadLine();
        int teamNumber = int.Parse(input);
    }
}