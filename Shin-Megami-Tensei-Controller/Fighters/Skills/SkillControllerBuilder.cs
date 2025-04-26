using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Fighters.Skills.SkillHits;
using Shin_Megami_Tensei.Fighters.Skills.SkillTargets;
using Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

namespace Shin_Megami_Tensei.Fighters.Skills;

public static class SkillControllerBuilder
{
    
    public static ISkillController FromSkill(Skill skill)
    {
        if (skill.Name == "Invitation")
            return new Invitation(skill);
        if (skill.Name == "Sabbatma")
            return new Sabbatma(skill);
        ISkillType type = SkillTypesFactory.GetSkillType(skill.Type, skill.Name);
        ISkillTargets targets = SkillTargetsFactory.GetSkillTargets(skill.Target, skill.Name);
        ISkillHits hits = SkillHitFactory.GetSkillHits(skill.Hits);
        SkillController controller = new SkillController(skill, type, hits, targets);
        return controller;
    }
}