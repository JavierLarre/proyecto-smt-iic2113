using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public class SingleSkillTarget: ISkillTargets
{
    private IFighter? _target = null;
    
    public ICollection<IFighter> GetTargets()
    {
        if (_target is null)
            InitializeTarget();
        return [_target!];
    }

    private void InitializeTarget()
    {
        Table table = Table.GetInstance();
        IFighter attacker = table.GetCurrentFighter();
        var targets = table.GetEnemyTeamAliveTargets().ToList();
        TargetMenu targetMenu = new TargetMenu(attacker, targets);
        _target = targetMenu.GetTarget();
    }
}