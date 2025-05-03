using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class SamuraiInvoke: AbstractInvoke
{
    protected override int GetSummonPosition()
    {
        var targets = new SummonablePositionsController().GetPositions();
        SummonPositionsMenu positionsMenu = new SummonPositionsMenu(targets);
        return positionsMenu.GetPosition();
    }
}