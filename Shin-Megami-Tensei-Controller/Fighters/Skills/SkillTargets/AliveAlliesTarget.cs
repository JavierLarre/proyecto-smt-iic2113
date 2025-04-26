using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public class AliveAlliesTarget : ISkillTargets
{
    private IFighter? _target;

    public ICollection<IFighter> GetTargets()
    {
        if (_target is null)
            InitializeTarget();
        return [_target!];
    }

    private void InitializeTarget()
    {
        Table table = Table.GetInstance();
        var targets = table.GetCurrentPlayer().GetTeam().GetAliveFront();
        TargetMenu menu = new TargetMenu(table.GetCurrentFighter(), targets);
        _target = menu.GetTarget();
    }
}