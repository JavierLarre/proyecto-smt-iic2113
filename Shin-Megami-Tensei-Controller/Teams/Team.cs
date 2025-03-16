using Shin_Megami_Tensei.Monsters;
using Shin_Megami_Tensei.Samurais;

namespace Shin_Megami_Tensei.Teams;

public class Team
{
    private Samurai Samurai;
    private Monster[] Monsters;

    public static Team FromStringLines(string[] lines)
    {
        TeamParser teamParser = new TeamParser(lines);
        return new Team(
            teamParser.Samurais.First(),
            teamParser.Monsters.ToArray()
            );
    }
    
    private Team(Samurai samurai, Monster[] monsters)
    {
        Samurai = samurai;
        Monsters = monsters;
    }
}