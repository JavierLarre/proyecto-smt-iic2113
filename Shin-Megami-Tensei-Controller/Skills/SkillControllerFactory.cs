using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

namespace Shin_Megami_Tensei.Fighters.Skills;

public static class SkillControllerFactory
{
    
    public static ISkillController FromData(SkillData skill)
    {
        return skill.Name switch
        {
            "Invitation" => new Invitation(skill),
            "Sabbatma" => new Sabbatma(skill),
            _ => GetCommonSkill(skill)
        };
    }

    private static SkillController GetCommonSkill(SkillData skill)
    {
        SkillController controller = new SkillController(skill);
        return controller;
    }
}