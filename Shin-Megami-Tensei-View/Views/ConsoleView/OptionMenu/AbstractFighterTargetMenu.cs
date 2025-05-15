using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public abstract class AbstractFighterTargetMenu: AbstractOptionsMenu
{
    private ICollection<IFighterModel> _targets = [];

    protected void SetTargets(ICollection<IFighterModel> targets) => _targets = targets;
    protected ICollection<IFighterModel> GetTargets() => _targets;
    
    public IFighterModel GetTarget()
    {
        string targetName = GetChoice();
        IFighterModel choosenTarget = _targets.
            First(target => target.GetUnitData().Name == targetName);
        return choosenTarget;
    }
}