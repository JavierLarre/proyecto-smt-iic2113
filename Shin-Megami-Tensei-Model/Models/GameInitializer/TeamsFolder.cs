namespace Shin_Megami_Tensei_Model;

public class TeamsFolder
{
    public string Path { get; }
    private readonly string[] _fileNames;

    public IEnumerable<string> FileNames => _fileNames;

    public TeamsFolder(string path)
    {
        Path = path;
        CheckFolderPathValidity();
        _fileNames = GetFileNamesFromDir();
    }

    public string GetTeamFileName(int index)
    {
        return _fileNames[index];
    }

    private string[] GetFileNamesFromDir()
    {
        return Directory.GetFiles(Path)
            .Select(System.IO.Path.GetFileName)
            .Where(name => !string.IsNullOrEmpty(name))
            .ToArray()!;
    }

    private void CheckFolderPathValidity()
    {
        if (!Directory.Exists(Path))
            throw new DirectoryNotFoundException();
    }
}