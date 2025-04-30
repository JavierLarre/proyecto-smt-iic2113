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
    public IEnumerable<IFighter> GetDeadFront()
    {
        return _frontRow.Where(fighter => !fighter.IsAlive());
    }
    public ICollection<IFighter> GetReserve() => _reserve;

    public IEnumerable<IFighter> GetAllFighters()
    {
        return _frontRow.Concat(_reserve);
    }

    public void Summon(IFighter inFighter, int atPosition)
    {
        IFighter outFighter = _frontRow[atPosition];
        _reserve.Add(outFighter);
        _frontRow[atPosition] = inFighter;
        _reserve.Remove(inFighter);
        SortReserve();
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

    public IEnumerable<IFighter> GetDeadFighters()
    {
        var deadFighters = GetAllFighters()
            .Where(fighter => !fighter.IsAlive())
            .ToList();
        var demonLibray = new DemonFactory().GetDemonLibrary();
        var deadFightersNames = deadFighters
            .Select(fighter => fighter.GetUnitData().Name).ToHashSet();
        var filteredLibrary = demonLibray
            .Where(demon => deadFightersNames.Contains(demon.GetUnitData().Name))
            .Select(demon => demon.GetUnitData().Name);
        List<IFighter> sortedDeadFighters = [];
        foreach (string demonName in filteredLibrary)
        {
            var deadDemon = deadFighters
                .First(demon => demon.GetUnitData().Name == demonName);
            sortedDeadFighters.Add(deadDemon);
        }

        foreach (IFighter deadFighter in deadFighters)
        {
            if (deadFighter is Samurai)
                sortedDeadFighters.Insert(0, deadFighter);
        }

        return sortedDeadFighters;
    }

    private void SortReserve()
    {
        var demonLibrary = new DemonFactory().GetDemonLibrary();
        var reserveNames = _reserve.Select(fighter => fighter.GetUnitData().Name).ToHashSet();
        var filteredLibrary = demonLibrary.
            Where(demon => reserveNames.Contains(demon.GetUnitData().Name));
        List<IFighter> newReserve = [];
        foreach (IFighter demon in filteredLibrary)
        {
            var reserveDemon = _reserve
                .First(reserveDemon => reserveDemon.GetUnitData().Name == demon.GetUnitData().Name);
            newReserve.Add(reserveDemon);
        }

        _reserve = newReserve;
    }


    public void Update()
    {
        throw new NotImplementedException();
    }
}