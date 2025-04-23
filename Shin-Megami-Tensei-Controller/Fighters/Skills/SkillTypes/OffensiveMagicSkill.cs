using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public abstract class OffensiveMagicSkill: OffensiveSkillType
{
    protected override int GetSkillStatFromAttacker() => GetAttacker().GetStats().Mag;
}