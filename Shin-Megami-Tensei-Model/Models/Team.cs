using Shin_Megami_Tensei_Model.Fighters;

namespace Shin_Megami_Tensei_Model;

public class Team
{
    private readonly IFighter[] _frontRow = new IFighter[Constants.MaxSizeFrontRow];
    private readonly IList<IFighter> _reserve;
    private int _fullturnsLeft = 0;
    private int _blinkingTurnsLeft = 0;
    
    public Team(ICollection<IFighter> frontRow, ICollection<IFighter> reserve)
    {
        int i = 0;
        foreach (IFighter fighter in frontRow)
        {
            _frontRow[i] = fighter;
            i++;
        }

        while (i < Constants.MaxSizeFrontRow)
        {
            _frontRow[i] = new EmptyFighter();
            i++;
        }
        _reserve = reserve.ToList();
        _fullturnsLeft = frontRow.Count;
    }

    public int GetFullTurnsLeft() => _fullturnsLeft;
    public int GetBlinkingTurnsLeft() => _blinkingTurnsLeft;

    public void ResetTurns()
    {
        _fullturnsLeft = GetAliveFront().Count();
        _blinkingTurnsLeft = 0;
    }

    public IEnumerable<IFighter> GetFightOrder()
    {
        var originalOrder = GetAliveFront()
            .OrderBy(fighter => fighter.GetStats().Spd * -1)
            .ToArray();
        int rotation = originalOrder.Length - _fullturnsLeft;
        for (int i = 0; i < originalOrder.Length; i++)
        {
            int index = (i + rotation) % originalOrder.Length;
            yield return originalOrder[index];
        }
    }
    
    public IFighter GetLeader() => _frontRow[0];
    public IEnumerable<IFighter> GetFrontRow() => _frontRow;
    public IEnumerable<IFighter> GetAliveFront() => _frontRow.Where(fighter => fighter.IsAlive());
    public ICollection<IFighter> GetReserve() => _reserve;

    public ICollection<IFighter> GetAllFighters()
    {
        return _frontRow.Concat(_reserve).ToList();
    }
    

    public void ConsumeTurn()
    {
        _fullturnsLeft--;
    }
}