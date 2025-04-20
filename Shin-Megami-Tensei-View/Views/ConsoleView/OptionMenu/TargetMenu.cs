using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class TargetMenu: AbstractOptionsMenu
{
    private string _header;
    
    public TargetMenu(IFighter attacker, IEnumerable<IFighter> targets)
    {
        foreach (IFighter target in targets)
        {
            IFighterView targetView = FighterViewFactory.FromFighter(target);
            AddOption(targetView.GetName(), targetView.GetInfo());
        }
        AddOption("Cancelar", "Cancelar");
        _header = $"Seleccione un objetivo para {attacker.Name}";
    }

    public override string GetHeader() => _header;
    public override string GetSeparator() => "-";
}