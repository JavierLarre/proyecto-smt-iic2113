namespace Shin_Megami_Tensei.Teams;

public class TeamsFolder
{
    private readonly string _folderPath;
    private readonly string[] _fileNames;

    public TeamsFolder(string folderPath)
    {
        _folderPath = folderPath;
        CheckFolderPath();
        _fileNames = GetFileNames().ToArray();
    }

    public string PrintFileNames()
    {
        var namesWithIndex = _fileNames.
            Select((name, index) => $"{index}: {name}");
        string allNamesWithNewlines = string.Join("\n", namesWithIndex);
        return allNamesWithNewlines;
    }

    public TeamsFile ReadTeamFile(int fileNumber)
    {
        string fileName = _fileNames[fileNumber];
        string filePath = Path.Join(_folderPath, fileName);
        TeamsFile file = new TeamsFile(filePath);
        return file;
    }
    
    private IEnumerable<string> GetFileNames()
    {
        var fileNames = Directory.GetFiles(_folderPath)
            .Select(Path.GetFileName);
        return fileNames.Where(name => !string.IsNullOrEmpty(name))!;
    }

    private void CheckFolderPath()
    {
        if (!Directory.Exists(_folderPath))
            throw new FileNotFoundException();
    }
    
}