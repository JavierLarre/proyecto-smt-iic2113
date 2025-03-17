using Shin_Megami_Tensei.Monsters;
using Shin_Megami_Tensei.Samurais;

namespace Shin_Megami_Tensei.Teams;

public class Team
{
    private Samurai Samurai;
    private Monster[] Monsters;

    public Team(TeamParser parser)
    {
        Samurai = parser.Samurais.First();
        Monsters = parser.Monsters.ToArray();
    }
}