
using Shin_Megami_Tensei.Fighters;
using Shin_Megami_Tensei.Fighters.Monsters;
using Shin_Megami_Tensei.Fighters.Samurais;

namespace Shin_Megami_Tensei.Teams;

public class Team
{
    public Samurai Samurai;
    public Monster[] Monsters;
    private TableRow _row;
    public int TurnsLeft => _row.TurnsLeft; //TODO: mal

    public static Team FromParser(TeamParser parser) =>
        new (parser);
    
    public override string ToString() =>_row.ToString();

    private Team(TeamParser parser)
    {
        Samurai = parser.Samurais.First();
        Monsters = parser.Monsters.ToArray();
        _row = TableRow.FromTeam(this);
    }

    public Fighter?[] Units() => _row.Units();

    public bool HasLost()
    {
        //TODO: agregar metodo IsDead a Fighter
        foreach(var fighter in _row.Units())
            if (fighter is not null)
                if(fighter.Stats.HpLeft != 0)
                    return false;
        return true;
    }

    public void Clear()
    {
        _row.Clear();
    }

    public bool HasFighter(Fighter fighter)
    {
        if (Samurai == fighter) return true;
        return Monsters.Contains(fighter);
    }

    public void CleanRows()
    {
        _row.Clean();
    }

    public IEnumerable<Fighter> TurnOrder() => _row.TurnOrder();
}