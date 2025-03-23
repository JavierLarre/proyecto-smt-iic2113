
using Shin_Megami_Tensei.Fighters;

namespace Shin_Megami_Tensei.Teams;

public class Table(Team[] teams)
{
    public Team[] Teams = teams;
    private int _turnsPlayed = 0; 
    public int PlayerTurn => GetPlayerFromTeam(CurrentTeam);
    public Team CurrentTeam = teams[0];
    public Team EnemyTeam => Teams[(PlayerTurn + 1) % Teams.Length];
    
    public void EndRound()
    {
        CurrentTeam = EnemyTeam;
        _turnsPlayed = 0;
    }

    public string PrintInfo()
    {
        //TODO: estoy seguro que esto puede ser mejor
        var playersTeamInString = Teams.Select(PrintPlayerBanner);
        return string.Join('\n', playersTeamInString);
    }

    public IEnumerable<Fighter> GetFightOrder()
    {
        Fighter[] fightOrder = CurrentTeam.TurnOrder().ToArray();
        return fightOrder
            .Select((_, i) => fightOrder[(i + _turnsPlayed) % fightOrder.Length]);
    }
    public int GetPlayerFromTeam(Team team) => Array.IndexOf(Teams, team);
    public int TurnsLeft => CurrentTeam.FullTurns - _turnsPlayed;
    public void EndTurn() => _turnsPlayed++;
    public Fighter NextFighterInOrder() => GetFightOrder().First();
    public bool IsRoundDone() => !(TurnsLeft > 0);
    public Team GetTeamFromFighter(Fighter fighter) =>
         Teams.First(team => team.HasFighter(fighter));
    
    public bool HasTeamLost() => Teams.Any(team => team.HasLost());
    public Team GetWinner() => Teams.First(team => !team.HasLost());
    
    private string PrintPlayerBanner(Team team) =>
        $"Equipo de {team.Samurai.Name} " +
        $"(J{GetPlayerFromTeam(team)+1})\n" +
        $"{team.PrintFighters()}";
    
    
}