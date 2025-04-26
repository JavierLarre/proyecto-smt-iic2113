using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public class AllySkillTarget: ISkillTargets
{
    private ISkillTargets _allyTargets;
    
    public AllySkillTarget(string skillName)
    {
        _allyTargets = DoesSkillRevive(skillName) ?
            new ReviveSkillTarget() :
            new AliveAlliesTarget();
    }
    
    public ICollection<IFighter> GetTargets()
    {
        return _allyTargets.GetTargets();
    }

    private static bool DoesSkillRevive(string skillName)
    {
        return skillName.Contains("ecarm") || skillName.Contains("Sabbatma");
    }
}