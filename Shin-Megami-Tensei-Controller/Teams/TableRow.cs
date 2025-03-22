using Shin_Megami_Tensei.Fighters;
using Shin_Megami_Tensei.Fighters.Monsters;
using Shin_Megami_Tensei.Fighters.Samurais;

namespace Shin_Megami_Tensei.Teams;

public class TableRow
{
    private Fighter?[] _fighters =
        new Fighter[Constants.MaxActiveFighters];

    private int _fightersAmount;
    private const string RowPositions = "ABCDEFGHI"; //alphabet

    public int TurnsLeft
    {
        get
        {
            if (_fighters[0].Stats.HpLeft == 0) return _fightersAmount - 1;
            return _fightersAmount; //TODO: notar dependencias
        }
    }

    public static TableRow FromTeam(Team team) => 
        new (team);

    private TableRow(Team team)
    {
        AddSamurai(team.Samurai);
        AddMonstersUntilFull(team.Monsters);
    }

    public void Clear()
    {
        for (int i = 0; i < _fighters.Length; i++)
        {
            _fighters[i] = null;
        }
    }

    //TODO: diferencia de clean y clear
    public void Clean()
    {
        for (int i = 1; i < _fighters.Length; i++)
        {
            if (_fighters[i]?.Stats.HpLeft == 0)
            {
                _fighters[i] = null;
                _fightersAmount--;
            }
        }

    }

    //TODO: cambiar a metodo
    public override string ToString()
    {
        var rowStrings = _fighters
            .Select((fighter, i) => $"{RowPosition(i)}-{fighter}");
        return string.Join('\n', rowStrings);
    }

    //TODO: dependencias
    public IEnumerable<Fighter> TurnOrder()
    {
        return _fighters
            .Where(fighter => fighter is not null)
            .Where(fighter => fighter.Stats.HpLeft > 0) 
            .OrderBy(fighter => fighter.Stats.Spd * -1);
    }

    public Fighter?[] Units()
    {
        return _fighters;
    }

    private static char RowPosition(int position) =>
        RowPositions[position];

    private void AddSamurai(Samurai samurai)
    {
        if (_fighters[0] is null) _fightersAmount++;
        _fighters[0] = samurai;
    }
        

    private void AddMonstersUntilFull(Monster[] monsters)
    {
        foreach(var monster in monsters)
            AddMonster(monster);
    }

    private void AddMonster(Monster monster)
    {
        if (_fightersAmount >= Constants.MaxActiveFighters)
            return;
        _fighters[_fightersAmount] = monster;
        _fightersAmount++;
    }
}