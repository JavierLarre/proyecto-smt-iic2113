using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public class ReserveTargets: ISkillTargets
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
        Team team = table.GetCurrentPlayer().GetTeam();
        var deadUnits = team.GetReserve();
        SummonFighterMenu menu = new SummonFighterMenu(deadUnits);
        _target = menu.GetTarget();
    }
}