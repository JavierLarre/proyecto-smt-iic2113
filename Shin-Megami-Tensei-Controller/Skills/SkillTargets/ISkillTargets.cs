using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public interface ISkillTargets
{
    public ICollection<IFighterModel> GetTargets(Table table);
}