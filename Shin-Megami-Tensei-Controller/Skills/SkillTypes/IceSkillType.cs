using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class IceSkillType: OffensiveMagicSkill
{
    public IceSkillType(SkillData skillData) : base(skillData)
    {
    }

    protected override string GetAffinityString(Affinities affinities) => affinities.Ice;
}