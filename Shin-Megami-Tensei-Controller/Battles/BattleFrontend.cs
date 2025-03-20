using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Battles;

public class BattleFrontend(Team team, int round)
{
    private Team _currentTeam = team;
    private int _round = round;
    private readonly string _indent = new ('-', 40);

    public string PrintRound()
    {
        IEnumerable<string> printOrder = [
            RoundBanner(),
            PrintTurns(),
            PrintTeamInOrder(),
        ];
        printOrder = printOrder.Select(info => $"{_indent}\n{info}");
        string round = string.Join('\n', printOrder);
        return round;
    }

    public void ChangeTeam(Team team)
    {
        _currentTeam = team;
        _round++;
    }

    private string RoundBanner() =>
        $"Ronda de {_currentTeam.Samurai.Name}" +
        $" (J{_round})";
    
    private string PrintTurns() =>
        $"Full Turns: {_currentTeam.TurnsLeft}\n" +
        $"Blinking Turns: 0";

    private string PrintTeamInOrder()
    {
        var fightersInOrder = _currentTeam.TurnOrder();
        var orderStrings = fightersInOrder
            .Select((fighter, i) => $"{i+1}-{fighter.Name}");
        string orderedTeamInString = string.Join('\n', orderStrings);
        return $"Orden:\n{orderedTeamInString}";
    }
}