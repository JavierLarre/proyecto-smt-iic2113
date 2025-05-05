using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public class ReserveTargets: ISkillTargets, IViewController
{
    private IFighter? _target;
    private ICollection<IFighter> _reserve;

    public ReserveTargets()
    {
        Table table = Table.GetInstance();
        Team team = table.GetCurrentPlayer().GetTeam();
        _reserve = team.GetReserve().ToList();
    }
    
    public ICollection<IFighter> GetTargets()
    {
        if (_target is null)
            InitializeTarget();
        return [_target!];
    }

    private void InitializeTarget()
    {
        SummonFighterMenu menu = new SummonFighterMenu(_reserve);
        _target = menu.GetTarget();
    }

    public void OnInput(string input)
    {
        throw new NotImplementedException();
    }
}