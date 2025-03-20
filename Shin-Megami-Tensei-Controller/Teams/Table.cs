using Shin_Megami_Tensei.Fighters;

namespace Shin_Megami_Tensei.Teams;

public class Table(Team[] teams)
{
    private Team[] _teams = teams;

    public override string ToString()
    {
        var playersTeamInString = _teams.Select(PrintPlayerTeam);
        return string.Join('\n', playersTeamInString);
    }

    public int GetPlayerFromTeam(Team team) =>
        Array.IndexOf(_teams, team) + 1;

    private string PrintPlayerTeam(Team team) =>
        $"Equipo de {team.Samurai.Name} (J{GetPlayerFromTeam(team)})\n{team}";
}