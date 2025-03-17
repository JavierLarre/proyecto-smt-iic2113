using Shin_Megami_Tensei.Monsters;
using Shin_Megami_Tensei.Samurais;

namespace Shin_Megami_Tensei.Teams;

public class Team
{
    public Samurai Samurai;
    public Monster[] Monsters;

    public static Team FromParser(TeamParser parser)
    {
        return new Team(parser);
    }

    private Team(TeamParser parser)
    {
        Samurai = parser.Samurais.First();
        Monsters = parser.Monsters.ToArray();
    }
}