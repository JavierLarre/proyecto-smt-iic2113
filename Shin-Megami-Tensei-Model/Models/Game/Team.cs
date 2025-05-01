using Shin_Megami_Tensei_Model.Fighters;

namespace Shin_Megami_Tensei_Model;

public class Team: AbstractModel, IModelObserver
{
    private readonly IFighter[] _frontRow;
    private IList<IFighter> _reserve;
    
    public Team(ICollection<IFighter> frontRow, ICollection<IFighter> reserve)
    {
        _frontRow = frontRow.ToArray();
        _reserve = reserve.ToList();
        SubscribeToFighters();
    }

    private void SubscribeToFighters()
    {
        var allFighters = _frontRow.Concat(_reserve);
        foreach (IFighter fighter in allFighters)
            fighter.AddObserver(this);
    }


    public IEnumerable<IFighter> GetFightOrder()
    {
        var order = GetAliveFront()
            .OrderBy(fighter => fighter.GetUnitData().Stats.Spd * -1);
        return order;
    }
    
    public IFighter GetLeader() => _frontRow[0];
    public IEnumerable<IFighter> GetFrontRow() => _frontRow;
    public IEnumerable<IFighter> GetAliveFront()
    {
        return _frontRow.Where(fighter => fighter.IsAlive());
    }
    public IEnumerable<IFighter> GetReserve() => _reserve;
    public void Summon(IFighter inFighter, int atPosition)
    {
        _reserve.Remove(inFighter);
        IFighter outFighter = _frontRow[atPosition];
        outFighter.AddToReserve(this);
        _frontRow[atPosition] = inFighter;
        SortReserve();
    }
    
    public void Update()
    {
        foreach (IFighter fighter in _frontRow)
            if (!fighter.IsAlive())
                fighter.AddToReserve(this);
    }

    public void MoveToReserve(IFighter fighter)
    {
        int fighterIndex = Array.IndexOf(_frontRow, fighter);
        if (fighterIndex == -1)
            return;
        _reserve.Add(fighter);
        SortReserve();
        _frontRow[fighterIndex] = new EmptyFighter();
    }

    private void SortReserve()
    {
        var sortedReserve = _reserve
            .OrderBy(fighter => fighter.GetUnitData().FilePriority);
        _reserve = sortedReserve.ToList();
    }
}