using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Fighters.Skills.SkillTypes;
using Shin_Megami_Tensei.Skills.SpecialCases;

namespace Shin_Megami_Tensei.Fighters.Skills;

public static class SkillControllerFactory
{
    
    public static ISkillController FromData(SkillData skill)
    {
        return skill.Name switch
        {
            "Invitation" => new Invitation(skill),
            "Sabbatma" => new Sabbatma(skill),
            "Bad Company" => new BadCompany(skill),
            "Trafuri" => new Trafuri(),
            "Defender's Gaze" => new DefendersGaze(skill),
            _ => GetCommonSkill(skill)
        };
    }

    private static SkillController GetCommonSkill(SkillData skill)
    {
        SkillController controller = new SkillController(skill);
        return controller;
    }
}