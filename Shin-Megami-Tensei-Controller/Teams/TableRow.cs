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
    public int TurnsLeft;

    public static TableRow FromTeam(Team team) => 
        new (team);

    public int TotalFullTurns() => _fightersAmount;

    private TableRow(Team team)
    {
        AddSamurai(team.Samurai);
        AddMonstersUntilFull(team.Monsters);
        TurnsLeft = TotalFullTurns();
    }


    public override string ToString()
    {
        var rowStrings = _fighters
            .Select((fighter, i) => $"{RowPosition(i)}-{fighter}");
        return string.Join('\n', rowStrings);
    }

    public Fighter[] TurnOrder()
    {
        return _fighters
            .Where(fighter => fighter is not null)
            .OrderBy(fighter => fighter.Stats.Spd).ToArray();
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