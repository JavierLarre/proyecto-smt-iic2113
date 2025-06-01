using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class ElecSkillType: OffensiveMagicSkill
{
    public ElecSkillType(SkillData skillData) : base(skillData)
    {
    }

    protected override string GetAffinityString(Affinities affinities) => affinities.Elec;
}