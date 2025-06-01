using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public class AllTargets: ISkillTargets
{
    public ICollection<IFighterModel> GetTargets(Table table)
    {
        return [];
    }
}