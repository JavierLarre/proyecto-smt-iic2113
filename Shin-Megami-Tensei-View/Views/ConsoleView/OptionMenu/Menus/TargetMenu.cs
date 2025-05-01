using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class TargetMenu: AbstractFighterTargetMenu
{
    
    public TargetMenu(IFighter attacker, IEnumerable<IFighter> targets)
    {
        SetTargets(targets.ToList());
        foreach (IFighter target in GetTargets())
        {
            IFighterView targetView = FighterViewFactory.FromFighter(target);
            AddOption(targetView.GetName(), targetView.GetInfo());
        }
        AddCancelOption();
        SetHeader($"Seleccione un objetivo para {attacker.GetUnitData().Name}");
    }

    protected override string GetSeparator() => "-";
}