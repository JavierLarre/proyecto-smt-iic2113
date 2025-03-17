namespace Shin_Megami_Tensei.Teams;

public class TeamsFolder
{
    private string FolderPath;
    private string[] FileNames;

    public TeamsFolder(string folderPath)
    {
        FolderPath = folderPath;
        CheckFolderPath();
        FileNames = GetFileNames();
    }

    public string PrintFileNames()
    {
        List<string> fileNames = FileNames.
            Select((name, index) => $"{index}: {name}")
            .ToList();
        return string.Join("\n", fileNames);
    }

    public TeamsFile ReadTeamFile(int fileNumber)
    {
        string fileName = FileNames[fileNumber];
        TeamsFile file = new TeamsFile(Path.Join(FolderPath, fileName));
        return file;
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