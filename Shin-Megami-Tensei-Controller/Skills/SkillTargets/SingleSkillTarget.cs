using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.TargetTypes;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public class SingleSkillTarget: ISkillTargets
{
    private SingleFighterMenuController? _targetController;

    public ICollection<IFighterModel> GetTargets(Table table)
    {
        if (_targetController is null)
        {
            var controllerBuilder = new SingleFighterMenuControllerBuilder(table);
            _targetController = controllerBuilder.BuildFromAliveEnemyTeam();
        }
        IFighterModel target = _targetController.GetTarget();
        return [target];
    }

}