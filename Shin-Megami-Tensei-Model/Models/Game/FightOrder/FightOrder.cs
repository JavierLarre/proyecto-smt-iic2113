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
        IFighterModel newFighter = FindNewFighter(teamState);
        try
        {
            IFighterModel previousFighter = FindOldFighter(teamState);
            RemovePreviousFighter(previousFighter, newFighter);
        }
        catch (ArgumentException e)
        {
            _fightersInOrder.AddLast(newFighter);
        }
    }

    private void RemovePreviousFighter(IFighterModel previousFighter, IFighterModel newFighter)
    {
        var node = _fightersInOrder.Find(previousFighter)!;
        _fightersInOrder.AddAfter(node, newFighter);
        _fightersInOrder.Remove(node);
    }

    private IFighterModel FindNewFighter(TeamState newTeamState)
    {
        var newFightOrder = newTeamState.FightersInOrder;
        foreach (IFighterModel fighter in newFightOrder)
        {
            if (_fightersInOrder.Contains(fighter))
                continue;
            return fighter;
        }

        throw new ArgumentException();
    }

    private IFighterModel FindOldFighter(TeamState newTeamState)
    {
        var newFightOrder = newTeamState.FightersInOrder;
        foreach (IFighterModel fighter in _fightersInOrder)
        {
            if (newFightOrder.Contains(fighter))
                continue;
            return fighter;
        }

        throw new ArgumentException();
    }
}