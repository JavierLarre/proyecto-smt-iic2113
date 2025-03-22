
using Shin_Megami_Tensei.Fighters;

namespace Shin_Megami_Tensei.Teams;

public class Table(Team[] teams)
{
    public Team[] Teams = teams;

    public override string ToString()
    {
        var playersTeamInString = Teams.Select(PrintPlayerTeamBanner);
        return string.Join('\n', playersTeamInString);
    }

    public Team GetEnemyTeam(Team currentTeam)
    {
        return Teams[0] == currentTeam ? Teams[1] : Teams[0];
    }

    public int GetPlayerFromTeam(Team team) =>
        Array.IndexOf(Teams, team) + 1;

    public Team GetTeamFromPlayer(int player) => Teams[player - 1];

    public Team GetTeamFromFighter(Fighter fighter)
    {
        return Teams.First(team => team.HasFighter(fighter));
    }
    public bool HasTeamLost()
    {
        return Teams.Any(team => team.HasLost());
    }

    public void CleanRows()
    {
        foreach (var team in Teams)
        {
            team.CleanRows();
        }
    }

    public Team GetWinner()
    {
        return Teams.First(team => !team.HasLost());
    }
    private string PrintPlayerTeamBanner(Team team) =>
        $"Equipo de {team.Samurai.Name} (J{GetPlayerFromTeam(team)})\n{team}";
}