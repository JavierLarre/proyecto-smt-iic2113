using Shin_Megami_Tensei_Model.Fighters;

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
        IFighterModel newFighter = teamState.LastSummonedFighter;
        IFighterModel previousFighter = teamState.LastReservedFighter;
        if (_fightersInOrder.Contains(previousFighter))
            RemovePreviousFighter(previousFighter, newFighter);
        else
            _fightersInOrder.AddLast(newFighter);
    }

    private void RemovePreviousFighter(IFighterModel previousFighter, IFighterModel newFighter)
    {
        var node = _fightersInOrder.Find(previousFighter)!;
        _fightersInOrder.AddAfter(node, newFighter);
        _fightersInOrder.Remove(node);
    }
}