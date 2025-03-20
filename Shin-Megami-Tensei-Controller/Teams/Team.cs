
using Shin_Megami_Tensei.Fighters;
using Shin_Megami_Tensei.Fighters.Monsters;
using Shin_Megami_Tensei.Fighters.Samurais;

namespace Shin_Megami_Tensei.Teams;

public class Team
{
    public Samurai Samurai;
    public Monster[] Monsters;
    private TableRow _row;
    public int TurnsLeft => _row.TurnsLeft;

    public static Team FromParser(TeamParser parser) =>
        new (parser);

    private Team(TeamParser parser)
    {
        Samurai = parser.Samurais.First();
        Monsters = parser.Monsters.ToArray();
        _row = TableRow.FromTeam(this);
    }

    public override string ToString()
    {
        return _row.ToString();
    }

    public Fighter[] TurnOrder() => _row.TurnOrder();
}