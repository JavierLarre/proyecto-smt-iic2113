using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class ReviveMenu: AbstractFighterTargetMenu
{

    public ReviveMenu(GameState gameState, IEnumerable<IFighterModel> targets)
    {
        IFighterModel attacker = gameState.CurrentFighter;
        SetTargets(targets.ToList());
        AddTargets();
        AddCancelOption();
        SetHeader($"Seleccione un objetivo para {attacker.GetState().Name}");
    }

    private void AddTargets()
    {
        foreach (IFighterModel target in GetTargets())
            AddTargetOption(target);
    }

    private void AddTargetOption(IFighterModel target)
    {
        IFighterView targetView = FighterViewFactory.FromFighter(target);
        string targetInfo = $"{target.GetState().Name} {targetView.GetStats()}";
        AddOption(targetView.GetName(), targetInfo);
    }
    
    protected override string GetSeparator() => "-";
}