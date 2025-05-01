using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public abstract class AbstractFighterTargetMenu: AbstractOptionsMenu
{
    private ICollection<IFighter> _targets = [];

    protected void SetTargets(ICollection<IFighter> targets) => _targets = targets;
    protected ICollection<IFighter> GetTargets() => _targets;
    
    public IFighter GetTarget()
    {
        string targetName = GetChoice();
        IFighter choosenTarget = _targets.
            First(target => target.GetUnitData().Name == targetName);
        return choosenTarget;
    }
}