using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.TargetTypes;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public class AliveAlliesTarget : ISkillTargets
{
    private SingleFighterMenuController? _controller;

    public ICollection<IFighterModel> GetTargets(Table table)
    {
        if (_controller is not null) 
            return [_controller.GetTarget()];
        
        var builder = new SingleFighterMenuControllerBuilder(table);
        _controller = builder.BuildFromAliveCurrentTeam();
        return [_controller.GetTarget()];
    }
}