using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class SummonFighterMenu: AbstractFighterTargetMenu
{

    public SummonFighterMenu(IEnumerable<IFighterModel> targets)
    {
        SetTargets(targets.ToList());
        var views = GetTargets().Select(FighterViewFactory.FromFighter);
        foreach (IFighterView target in views)
        {
            AddOption(target.GetName(), target.GetInfo());
        }
        AddCancelOption();
        SetHeader("Seleccione un monstruo para invocar");
    }

    
    protected override string GetSeparator() => "-";
}