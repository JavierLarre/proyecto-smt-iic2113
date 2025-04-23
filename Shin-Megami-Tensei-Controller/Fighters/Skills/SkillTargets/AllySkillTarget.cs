using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public class AllySkillTarget: ISkillTargets
{
    private Table _table = Table.GetInstance();
    private ICollection<IFighter> _targets;
    
    public AllySkillTarget(string skillName)
    {
        _targets = DoesSkillRevive(skillName) ? GetDeadTargets() : GetAliveTargets();
    }
    
    public ICollection<IFighter> GetTargets()
    {
        BattleView view = BattleViewSingleton.GetBattleView();
        IFighter attacker = _table.GetCurrentFighter();
        IOptionMenu targetMenu = new TargetMenu(attacker, _targets);
        string targetName = view.GetChoiceFromOptionMenu(targetMenu);
        IFighter target = _targets.First(target => target.GetName() == targetName);
        return [target];
    }

    private ICollection<IFighter> GetAliveTargets()
    {
        return _table.GetCurrentPlayer().GetTeam().GetAllFighters()
            .Where(fighter => fighter.IsAlive()).ToList();
    }

    private ICollection<IFighter> GetDeadTargets()
    {
        return _table.GetCurrentPlayer().GetTeam().GetAllFighters()
            .Where(fighter => !fighter.IsAlive()).ToList();
    }

    private static bool DoesSkillRevive(string skillName)
    {
        return skillName.Contains("ecarm");
    }
}