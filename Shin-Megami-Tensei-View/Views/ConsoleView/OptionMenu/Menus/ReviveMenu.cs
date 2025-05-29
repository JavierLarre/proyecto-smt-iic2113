using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class ReviveMenu: AbstractFighterTargetMenu
{
    private Table _table = Table.GetInstance();

    public ReviveMenu(IEnumerable<IFighterModel> targets)
    {
        IFighterModel attacker = _table.GetCurrentFighter();
        SetTargets(targets.ToList());
        AddTargets();
        AddCancelOption();
        SetHeader($"Seleccione un objetivo para {attacker.GetUnitData().Name}");
    }

    private void AddTargets()
    {
        foreach (IFighterModel target in GetTargets())
            AddTargetOption(target);
    }

    private void AddTargetOption(IFighterModel target)
    {
        IFighterView targetView = FighterViewFactory.FromFighter(target);
        string targetInfo = $"{target.GetUnitData().Name} {targetView.GetStats()}";
        AddOption(targetView.GetName(), targetInfo);
    }
    
    protected override string GetSeparator() => "-";
}