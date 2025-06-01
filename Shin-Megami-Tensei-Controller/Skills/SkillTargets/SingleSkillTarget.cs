using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.TargetTypes;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public class SingleSkillTarget: ISkillTargets
{
    private SingleEnemyTarget _targetController;

    public SingleSkillTarget()
    {
        Table table = Table.GetInstance();
        _targetController = new SingleEnemyTarget(table);
    }
    
    public ICollection<IFighterModel> GetTargets()
    {
        IFighterModel target = _targetController.GetTarget();
        return [target];
    }
}