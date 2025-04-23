using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class SummonPositionMenu: AbstractOptionsMenu
{
    public SummonPositionMenu()
    {
        Table table = Table.GetInstance();
        
    }

    
    public override string GetSeparator() => "-";
}