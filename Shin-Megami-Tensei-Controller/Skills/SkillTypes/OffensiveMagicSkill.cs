using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public abstract class OffensiveMagicSkill: OffensiveSkillType
{
    protected OffensiveMagicSkill(SkillData skillData) : base(skillData)
    {
    }

    protected override int GetSkillStat(Stats stats) => stats.Mag;
}