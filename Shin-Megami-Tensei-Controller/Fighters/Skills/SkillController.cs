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

    public void UseSkill()
    {
        int hits = _hits.CalculateHits();
        var targets = _targets.GetTargets();
        foreach (IFighter target in targets)
            for (int i = 0; i < hits; i++)
            {
                _type.ApplyEffect(target, _skill.Power);
            }

        DecreaseCurrentFighterMp();
        IncreaseCurrentPlayerUsedSkills();
    }

    private void DecreaseCurrentFighterMp()
    {
        int cost = _skill.Cost;
        IFighter user = Table.GetInstance().GetCurrentFighter();
        user.DecreaseMp(cost);
    }

    private static void IncreaseCurrentPlayerUsedSkills()
    {
        Table table = Table.GetInstance();
        table.IncreaseCurrentPlayerUsedSkillsCount();
    }
}