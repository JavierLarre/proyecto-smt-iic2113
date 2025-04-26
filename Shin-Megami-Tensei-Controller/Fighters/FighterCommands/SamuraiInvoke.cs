using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class SamuraiInvoke: AbstractInvoke
{
    protected override int GetSummonPosition()
    {
        SummonPositionMenu positionMenu = new SummonPositionMenu();
        return positionMenu.GetPosition();
    }
}