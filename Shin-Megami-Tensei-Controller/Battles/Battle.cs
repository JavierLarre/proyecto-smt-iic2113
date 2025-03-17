using Shin_Megami_Tensei.Samurais;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Battles;

public class Battle(Team[] teams)
{
    private Team[] Teams = teams;
    private int Round = 0;
    private int Turn => Round % Teams.Length;
    private Team CurrentTeam => Teams[Turn];
    private readonly string Indent = new string('-', 50);

    public string PrintRound()
    {
        return RoundBanner() + PrintCurrentTeam();
    }

    private string RoundBanner() =>
        $"{Indent}\nRonda de {CurrentTeam.Samurai.Name} (J{Turn}\n{Indent})";

    private string PrintCurrentTeam()
    {
        return $"Equipo de {CurrentTeam.Samurai.Name}\n";
    }

    private string PrintSamurai() => $"A-{CurrentTeam.Samurai.Name} ";
    private string PrintSamuraiStats() => $"HP: {CurrentTeam.Samurai}";
}