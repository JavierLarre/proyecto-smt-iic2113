using Shin_Megami_Tensei_Model.Fighters;

namespace Shin_Megami_Tensei_Model;

public class Team: AbstractModel, IModelObserver
{
    private readonly IFighterModel[] _frontRow;
    private IList<IFighterModel> _reserve;
    
    public Team(ICollection<IFighterModel> frontRow, ICollection<IFighterModel> reserve)
    {
        _frontRow = frontRow.ToArray();
        _reserve = reserve.ToList();
        SubscribeToFighters();
    }

    private void SubscribeToFighters()
    {
        var allFighters = _frontRow.Concat(_reserve);
        foreach (IFighterModel fighter in allFighters)
            fighter.AddObserver(this);
    }


    public IEnumerable<IFighterModel> GetFightOrder()
    {
        var order = GetAliveFront()
            .OrderBy(fighter => fighter.GetUnitData().Stats.Spd * -1);
        return order;
    }
    
    public IFighterModel GetLeader() => _frontRow[0];
    public IEnumerable<IFighterModel> GetFrontRow() => _frontRow;
    public IEnumerable<IFighterModel> GetAliveFront()
    {
        return _frontRow.Where(fighter => fighter.IsAlive());
    }
    public IEnumerable<IFighterModel> GetReserve() => _reserve;
    public void Summon(IFighterModel inFighter, int atPosition)
    {
        _reserve.Remove(inFighter);
        IFighterModel outFighter = _frontRow[atPosition];
        outFighter.AddToReserve(this);
        _frontRow[atPosition] = inFighter;
        SortReserve();
        UpdateObservers();
    }
    
    public void Update()
    {
        foreach (IFighterModel fighter in _frontRow)
            if (!fighter.IsAlive())
                fighter.AddToReserve(this);
    }

    public void MoveToReserve(IFighterModel fighter)
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
    
    //todo: mover al principio
    public TeamState GetTeamState()
    {
        return new TeamState
        {
            Leader = _frontRow[0],
            FightersInOrder = GetFightOrder().ToList(),
            FrontRow = _frontRow,
            AliveFrontRow = GetAliveFront().ToList(),
            Reserve = _reserve
        };
    }
}