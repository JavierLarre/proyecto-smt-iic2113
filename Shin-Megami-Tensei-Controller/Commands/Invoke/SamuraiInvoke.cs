using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class SamuraiInvoke: AbstractInvoke
{

    protected override int GetSummonPosition(Table table)
    {
        var summonablePositionsController = new SummonablePositionsController(table);
        return summonablePositionsController.GetPositionFromUser();
    }
}