using Shin_Megami_Tensei_Model.Fighters;

namespace Shin_Megami_Tensei_Model;

public class TeamBuilder
{
    private readonly IFighterModel[] _frontRow = GetEmptyArray();
    private readonly IList<IFighterModel> _reserve = [];
    private int _frontRowLength;
    
    public Team FromFighters(ICollection<IFighterModel> fighters)
    {
        foreach (IFighterModel fighter in fighters)
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

    private static IFighterModel[] GetEmptyArray()
    {
        const int frontRowSize = GameConstants.MaxSizeFrontRow;
        var emptyFighters = Enumerable.Repeat(new EmptyFighter(), frontRowSize);
        return emptyFighters.ToArray<IFighterModel>();
    }
}