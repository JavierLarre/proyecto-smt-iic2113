using Shin_Megami_Tensei_Model.Fighters;

namespace Shin_Megami_Tensei_Model;

public class TeamBuilder
{
    private readonly IFighter[] _frontRow = GetEmptyArray();
    private readonly IList<IFighter> _reserve = [];
    private int _frontRowLength;
    
    public Team FromFighters(ICollection<IFighter> fighters)
    {
        foreach (IFighter fighter in fighters)
        {
            if (_frontRowLength < _frontRow.Length)
            {
                _frontRow[_frontRowLength] = fighter;
                _frontRowLength++;
            }
            else
                _reserve.Add(fighter);
        }

        return new Team(_frontRow, _reserve);
    }

    private static IFighter[] GetEmptyArray()
    {
        const int frontRowSize = Constants.MaxSizeFrontRow;
        var emptyFighters = Enumerable.Repeat(new EmptyFighter(), frontRowSize);
        return emptyFighters.ToArray<IFighter>();
    }
}