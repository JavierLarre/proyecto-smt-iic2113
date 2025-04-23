using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class TargetMenu: AbstractOptionsMenu
{
    
    public TargetMenu(IFighter attacker, IEnumerable<IFighter> targets)
    {
        foreach (IFighter target in targets)
        {
            IFighterView targetView = FighterViewFactory.FromFighter(target);
            AddOption(targetView.GetName(), targetView.GetInfo());
        }
        AddOption("Cancelar", "Cancelar");
        SetHeader($"Seleccione un objetivo para {attacker.GetName()}");
    }
    public override string GetSeparator() => "-";
}