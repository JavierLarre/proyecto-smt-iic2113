
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
        TeamState teamState = team.GetTeamState();
        IFighterModel leader = teamState.Leader;
        IFighterModel newFighter = teamState.LastSummonedFighter;

        if (AreListsEqual(teamState.FightersInOrder)) 
            return;
        if (ShouldLeaderBeAdded(leader))
        {
            _fightersInOrder.AddLast(leader);
        }
        else if (IsOrderOutOfDate(teamState))
        {
            RemovePreviousFighter(teamState);
        }
        else
        {
            _fightersInOrder.AddLast(newFighter);
        }
    }

    private bool IsOrderOutOfDate(TeamState teamState)
    {
        IFighterModel previousFighter = teamState.LastReservedFighter;
        return _fightersInOrder.Contains(previousFighter);
    }

    private bool ShouldLeaderBeAdded(IFighterModel leader)
    {
        return !_fightersInOrder.Contains(leader) && leader.GetState().IsAlive;
    }

    private bool AreListsEqual(ICollection<IFighterModel> fighters)
    {
        HashSet<IFighterModel> teamFighters = fighters.ToHashSet();
        HashSet<IFighterModel> fightersInOrder = _fightersInOrder.ToHashSet();
        bool haveSameElements = teamFighters.SetEquals(fightersInOrder);
        return haveSameElements;
    }

    private void RemovePreviousFighter(TeamState teamState)
    {
        IFighterModel previousFighter = teamState.LastReservedFighter;
        IFighterModel newFighter = teamState.LastSummonedFighter;
        var node = _fightersInOrder.Find(previousFighter)!;
        _fightersInOrder.AddAfter(node, newFighter);
        _fightersInOrder.Remove(node);
    }
}