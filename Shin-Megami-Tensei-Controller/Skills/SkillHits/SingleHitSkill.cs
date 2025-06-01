using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillHits;

public class SingleHitSkill: ISkillHits
{
    public int GetHits(Table table) => 1;
}