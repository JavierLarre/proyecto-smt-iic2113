
namespace Shin_Megami_Tensei_Model;

public class FightOrder: AbstractModel
{
    private LinkedList<IFighterModel> _fightersInOrder = [];

    public int Count => _fightersInOrder.Count;

    public ICollection<IFighterModel> GetFightersInTurnOrder()
        => _fightersInOrder;

    public IFighterModel GetCurrentFighter()
    {
        return _fightersInOrder.First();
    }

    public void CycleFighters()
    {
        IFighterModel first = _fightersInOrder.First();
        _fightersInOrder.RemoveFirst();
        _fightersInOrder.AddLast(first);
    }

    public void SetFightOrderFrom(Team team)
    {
        TeamState teamState = team.GetTeamState();
        _fightersInOrder = new LinkedList<IFighterModel>(teamState.FightersInOrder);
    }

    public void UpdateFightOrderFrom(Team team)
    {
        if (AreListsEqual(team.GetTeamState().FightersInOrder)) 
            return;
        TeamState teamState = team.GetTeamState();
        IFighterModel leader = teamState.Leader;
        if (!_fightersInOrder.Contains(leader) && leader.GetState().IsAlive)
        {
            _fightersInOrder.AddLast(leader);
            return;
        }
        IFighterModel newFighter = teamState.LastSummonedFighter;
        IFighterModel previousFighter = teamState.LastReservedFighter;
        if (_fightersInOrder.Contains(previousFighter))
            RemovePreviousFighter(previousFighter, newFighter);
        else
            _fightersInOrder.AddLast(newFighter);
    }

    private bool AreListsEqual(ICollection<IFighterModel> fighters)
    {
        bool sameSize = fighters.Count == _fightersInOrder.Count;
        if (!sameSize) return false;
        HashSet<IFighterModel> teamFighters = fighters.ToHashSet();
        HashSet<IFighterModel> fightersInOrder = _fightersInOrder.ToHashSet();
        bool haveSameElements = teamFighters.SetEquals(fightersInOrder);
        return haveSameElements;
    }

    private void RemovePreviousFighter(IFighterModel previousFighter, IFighterModel newFighter)
    {
        var node = _fightersInOrder.Find(previousFighter)!;
        _fightersInOrder.AddAfter(node, newFighter);
        _fightersInOrder.Remove(node);
    }
}