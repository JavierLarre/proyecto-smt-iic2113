using Shin_Megami_Tensei_Model;

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
    
    public ICollection<IFighterModel> GetTargets(Table table)
    {
        return _allyTargets.GetTargets(table);
    }

    private static bool DoesSkillRevive(string skillName)
    {
        return skillName.Contains("ecarm");
    }
}