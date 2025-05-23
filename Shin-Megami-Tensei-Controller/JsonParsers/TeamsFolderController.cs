﻿using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei_View.Views.ConsoleView.GameInitializer;

namespace Shin_Megami_Tensei.Teams;

public class TeamsFolderController
{
    private readonly TeamsFolder _folder;
    private readonly TeamsFolderView _view;

    public TeamsFolderController(string folderPath, View view)
    {
        _folder = new TeamsFolder(folderPath);
        _view = new TeamsFolderView(_folder, view);
    }

    private TeamsFile GetTeamFile()
    {
        string nameTeamFile = _view.GetFileNameFromUser();
        string pathTeamFile = CombinePathWithName(nameTeamFile);
        return new TeamsFile(pathTeamFile);
    }

    public IEnumerable<Team> GetTeams()
    {
        TeamsFile file = GetTeamFile();
        return file.GetTeams();
    }

    private string CombinePathWithName(string fileName)
    {
        return Path.Combine(_folder.Path, fileName);
    }
}