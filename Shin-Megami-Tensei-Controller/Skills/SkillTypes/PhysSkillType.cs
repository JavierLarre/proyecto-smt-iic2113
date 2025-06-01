using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class PhysSkillType: OffensiveSkillType
{
    public PhysSkillType(SkillData skillData): base(skillData) { }

    protected override string GetAffinityString(Affinities affinities) => affinities.Phys;

    protected override int GetSkillStat(Stats stats) => stats.Str;
}