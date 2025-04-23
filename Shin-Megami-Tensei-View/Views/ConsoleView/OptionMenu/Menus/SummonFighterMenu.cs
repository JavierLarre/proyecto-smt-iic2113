using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class SummonFighterMenu: AbstractOptionsMenu
{

    public SummonFighterMenu(IEnumerable<IFighter> targets)
    {
        var views = targets.Select(FighterViewFactory.FromFighter);
        foreach (IFighterView target in views)
        {
            AddOption(target.GetName(), target.GetInfo());
        }
        AddOption("Cancelar", "Cancelar");
        SetHeader("Seleccione un monstro para invocar");
    }
    
    public override string GetSeparator() => "-";
}