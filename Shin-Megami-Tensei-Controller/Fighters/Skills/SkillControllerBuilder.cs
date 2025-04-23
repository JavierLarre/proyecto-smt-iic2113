using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Fighters.Skills.SkillHits;
using Shin_Megami_Tensei.Fighters.Skills.SkillTargets;
using Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

namespace Shin_Megami_Tensei.Fighters.Skills;

public static class SkillControllerBuilder
{
    
    public static SkillController FromSkill(Skill skill)
    {
        ISkillType type = SkillTypesFactory.GetSkillType(skill.Type);
        ISkillTargets targets = SkillTargetsFactory.GetSkillTargets(skill.Target, skill.Name);
        ISkillHits hits = SkillHitFactory.GetSkillHits(skill.Hits);
        SkillController controller = new SkillController(skill, type, hits, targets);
        return controller;
    }
}