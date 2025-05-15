using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public class ReserveTarget: ISkillTargets, IViewController
{
    private IFighterModel? _target;
    private readonly ICollection<IFighterModel> _reserve;

    public ReserveTarget()
    {
        Table table = Table.GetInstance();
        Team team = table.GetCurrentPlayer().GetTeam();
        _reserve = team.GetReserve().ToList();
    }
    
    public ICollection<IFighterModel> GetTargets()
    {
        if (_target is null)
            InitializeTarget();
        return [_target!];
    }

    private void InitializeTarget()
    {
        SummonFighterMenu menu = new SummonFighterMenu(_reserve);
        menu.SetInput(this);
        menu.GetChoice();
    }

    public void OnInput(string input)
    {
        _target = _reserve.First(IsFighterChoosenTarget);
        return;

        bool IsFighterChoosenTarget(IFighterModel fighter)
        {
            return fighter.GetUnitData().Name == input;
        }
    }
}