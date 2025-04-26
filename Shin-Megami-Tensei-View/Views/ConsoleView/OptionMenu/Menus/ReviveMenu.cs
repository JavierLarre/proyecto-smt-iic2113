using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class ReviveMenu: AbstractFighterTargetMenu
{
    private Table _table = Table.GetInstance();

    public ReviveMenu(IEnumerable<IFighter> targets)
    {
        IFighter attacker = _table.GetCurrentFighter();
        SetTargets(targets.ToList());
        AddTargets();
        AddCancelOption();
        SetHeader($"Seleccione un objetivo para {attacker.GetName()}");
    }

    private void AddTargets()
    {
        foreach (IFighter target in GetTargets())
            AddTargetOption(target);
    }

    private void AddTargetOption(IFighter target)
    {
        IFighterView targetView = FighterViewFactory.FromFighter(target);
        string targetInfo = $"{target.GetName()} {targetView.GetStats()}";
        AddOption(targetView.GetName(), targetInfo);
    }
    
    public override string GetSeparator() => "-";
}