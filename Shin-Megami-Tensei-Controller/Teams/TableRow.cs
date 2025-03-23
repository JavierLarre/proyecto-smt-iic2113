using Shin_Megami_Tensei.Fighters;
using Shin_Megami_Tensei.Fighters.Monsters;
using Shin_Megami_Tensei.Fighters.Samurais;

namespace Shin_Megami_Tensei.Teams;

public class TableRow
{
    private const int MaxActiveFighters = 4;
    private readonly Fighter?[] _fighters =
        new Fighter[MaxActiveFighters];

    private int _fightersAmount;
    private const string RowPositions = "ABCDEFGHI"; //alphabet

    public int FullTurns => ValidTargets().Count();

    public IEnumerable<Fighter> ValidTargets() =>
        _fighters.Where(fighter => fighter is not null)
        .Where(fighter => fighter.IsAlive());

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

    public string PrintFighters()
    {
        var rowStrings = _fighters
            .Select(FighterPosition);
        return string.Join('\n', rowStrings);
    }
    private string FighterPosition(Fighter? fighter, int i) =>
         fighter is null ?
             $"{RowPosition(i)}-" :
             $"{RowPosition(i)}-{fighter.PrintNameAndStats()}";

    public IEnumerable<Fighter> TurnOrder()
    {
        return _fighters
            .Where(fighter => fighter is not null)
            .Where(fighter => fighter.IsAlive()) 
            .OrderBy(fighter => fighter.Stats.Spd * -1);
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
        if (_fightersAmount >= MaxActiveFighters)
            return;
        _fighters[_fightersAmount] = monster;
        _fightersAmount++;
    }
}