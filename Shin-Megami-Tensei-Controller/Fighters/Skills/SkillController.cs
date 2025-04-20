using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Fighters.Skills.SkillHits;
using Shin_Megami_Tensei.Fighters.Skills.SkillTargets;
using Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

namespace Shin_Megami_Tensei.Fighters.Skills;

public class SkillController
{
    private Skill _skill;
    private ISkillType _type;
    private ISkillHits _hits;
    private ISkillTargets _targets;

    public SkillController(Skill skill, ISkillType type,
        ISkillHits hits, ISkillTargets targets)
    {
        _skill = skill;
        _type = type;
        _hits = hits;
        _targets = targets;
    }
}