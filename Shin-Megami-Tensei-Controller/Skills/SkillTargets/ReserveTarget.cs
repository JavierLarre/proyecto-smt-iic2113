using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.TargetTypes;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public class ReserveTarget: ISkillTargets
{
    private SingleFighterMenuController? _menuController;
    
    public ICollection<IFighterModel> GetTargets(Table table)
    {
        if (_menuController is null)
        {
            InitializeController(table);
        }
        return [_menuController!.GetTarget()!];
    }

    private void InitializeController(Table table)
    {
        var reserve = table.GetGameState()
            .CurrentPlayerState
            .TeamState
            .Reserve;
        SummonFighterMenu menu = new SummonFighterMenu(reserve);
        _menuController = new SingleFighterMenuController(menu);
        _menuController.SetFighters(reserve);
    }
}