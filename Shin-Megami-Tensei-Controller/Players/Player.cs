using Shin_Megami_Tensei.Fighters;
using Shin_Megami_Tensei.Fighters.Monsters;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Players;

public class Player
{
    private const int MaxActiveFighters = 4;
    private const int SamuraiPosition = 0;
    
    private Fighter?[] _frontRow = new Fighter[MaxActiveFighters];
    private List<Fighter> _reserve = [];
    private int _activeFighters = 0;
    private int _turnsLeft = 0;

    public Player(TeamParser validTeam)
    {
        _frontRow[SamuraiPosition] = validTeam.Samurais.First();
        _activeFighters++;
        AddMonstersToTeam(validTeam.Monsters);
    }

    public int GetTotalFullTurns() => _activeFighters;
    public int GetFullTurnsLeft() => _turnsLeft;
    

    private void AddMonstersToTeam(IEnumerable<Monster> monsters)
    {
        foreach (var monster in monsters) 
            AddFighterToTeam(monster);
    }

    private void AddFighterToTeam(Fighter fighter)
    {
        if (_activeFighters == MaxActiveFighters)
            _reserve.Add(fighter);
        else
            _frontRow[_activeFighters++] = fighter;
    }
}