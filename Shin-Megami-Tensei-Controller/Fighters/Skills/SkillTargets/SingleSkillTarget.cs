using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public class SingleSkillTarget: ISkillTargets
{
    public ICollection<IFighter> GetTargets()
    {
        Table table = Table.GetInstance();
        BattleView view = BattleViewSingleton.GetBattleView();
        IFighter attacker = table.GetCurrentFighter();
        var targets = table.GetEnemyTeamAliveTargets().ToList();
        IOptionMenu targetMenu = new TargetMenu(attacker, targets);
        string targetName = view.GetChoiceFromOptionMenu(targetMenu);
        IFighter reciever = targets.First(target => target.GetName() == targetName);
        return [reciever];
    }
}