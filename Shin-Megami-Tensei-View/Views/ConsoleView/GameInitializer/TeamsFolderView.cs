
using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.GameInitializer;

public class TeamsFolderView
{
    private readonly TeamsFolder _folder;
    private readonly View _view;

    public TeamsFolderView(TeamsFolder folder, View view)
    {
        _folder = folder;
        _view = view;
    }

    public string GetFileNameFromUser()
    {
        PrintFileNames();
        return GetSelectedFileNameFromUser();
    }

    private void PrintFileNames()
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        foreach (string fileName in GetFileNames())
        {
            _view.WriteLine(fileName);
        }
    }

    private string GetSelectedFileNameFromUser()
    {
        string choice = _view.ReadLine();
        int fileIndex = int.Parse(choice);
        return _folder.GetTeamFileName(fileIndex);
    }

    private IEnumerable<string> GetFileNames()
    {
        return _folder.FileNames
            .OrderBy(fileName => int.Parse(Path.GetFileNameWithoutExtension(fileName)))
            .Select((name, i) => $"{i}: {name}");
    }
}