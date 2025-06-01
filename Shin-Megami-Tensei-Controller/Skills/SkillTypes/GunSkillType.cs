using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class GunSkillType: OffensiveSkillType
{
    public GunSkillType(SkillData skillData) : base(skillData)
    {
    }

    

    protected override string GetAffinityString(Affinities affinities) => affinities.Gun;

    protected override int GetSkillStat(Stats stats) => stats.Skl;
}