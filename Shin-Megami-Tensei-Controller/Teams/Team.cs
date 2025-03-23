
using Shin_Megami_Tensei.Fighters;
using Shin_Megami_Tensei.Fighters.Monsters;
using Shin_Megami_Tensei.Fighters.Samurais;

namespace Shin_Megami_Tensei.Teams;

public class Team
{
    public readonly Samurai Samurai;
    public readonly Monster[] Monsters;
    private readonly TableRow _row;
    public int FullTurns => _row.FullTurns; 

    public static Team FromParser(TeamParser parser) =>
        new (parser);

    private Team(TeamParser parser)
    {
        Samurai = parser.Samurais.First();
        Monsters = parser.Monsters.ToArray();
        _row = TableRow.FromTeam(this);
    }

    public string PrintFighters() =>_row.PrintFighters();
    public IEnumerable<Fighter> ValidTargets() => _row.ValidTargets();
    public bool HasLost() => !_row.ValidTargets().Any();
    public void Clear() => _row.Clear();
    public IEnumerable<Fighter> TurnOrder() => _row.TurnOrder();
    public bool HasFighter(Fighter fighter) => Samurai == fighter || Monsters.Contains(fighter);
}