namespace Shin_Megami_Tensei.Teams;

public class TeamFiles
{
    private string FolderPath;
    private string[] FileNames;

    public TeamFiles(string folderPath)
    {
        FolderPath = folderPath;
        CheckFolderPath();
        FileNames = GetFileNames();
    }

    public string TeamNames()
    {
        List<string> teams = [];
        teams.AddRange(FileNames.Select((team, index) => $"{index}: {team}"));
        return string.Join("\n", teams);
    }

    public Team[] ReadTeamFile(int file)
    {
        string fileName = FileNames[file];
        string[] lines = File.ReadAllLines(Path.Join(FolderPath, fileName));
        return ReadTeamFile(lines);
    }

    private Team[] ReadTeamFile(string[] lines)
    {
        int teamOneLength = Array.IndexOf(lines, "Player 2 Team");
        string[] teamOneLines = lines[1..teamOneLength];
        string[] teamTwoLines = lines[(teamOneLength + 1) .. lines.Length];
        return [
            Team.FromStringLines(teamOneLines),
            Team.FromStringLines(teamTwoLines)
        ];
    }
    
    private string[] GetFileNames()
    {
        return Directory.GetFiles(FolderPath).Select(Path.GetFileName).ToArray();
    }

    private void CheckFolderPath()
    {
        if (!Directory.Exists(FolderPath))
            throw new FileNotFoundException();
    }
    
}