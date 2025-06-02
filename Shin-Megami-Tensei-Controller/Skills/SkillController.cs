using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Fighters.Skills.SkillHits;
using Shin_Megami_Tensei.Fighters.Skills.SkillTargets;
using Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

namespace Shin_Megami_Tensei.Fighters.Skills;

public class SkillController: ISkillController
{
    private SkillData _skillData;
    private ISkillType _type;
    private ISkillHits _hits;
    private ISkillTargets _targets;
    private Table _table = null!;

    public SkillController(SkillData skill)
    {
        _skillData = skill;
        _hits = SkillHitFactory.GetSkillHits(_skillData);
        _type = SkillTypesFactory.GetSkillType(_skillData);
        _targets = SkillTargetsFactory.GetSkillTargets(_skillData);
    }

    public void UseSkill(Table table)
    {
        _table = table;
        ApplyEffectsOnTargets();
        ConsumeTurns();
        DecreaseCurrentFighterMp();
        IncreaseCurrentPlayerUsedSkills();
    }

    private void ApplyEffectsOnTargets()
    {
        var targets = _targets.GetTargets(_table);
        ITypeView typeView = _type.GetActionView();
        typeView.StartDisplay();
        foreach (IFighterModel target in targets)
            SingularApplyEffect(target);
        
    }

    private void SingularApplyEffect(IFighterModel target)
    {
        _type.SetTarget(target);
        ITypeView typeView = _type.GetActionView();
        int hits = _hits.GetHits(_table);
        for (int i = 0; i < hits; i++)
        {
            _type.ApplyEffect(_table);
            typeView = _type.GetActionView();
            typeView.Display();
        }
        typeView.DisplayEnding();
    }

    private void ConsumeTurns()
    {
        var prioritizedAffinity = GetPrioritizedAffinity();
        TurnsModel turnsModel = _table.GetGameState().TurnsModel;
        prioritizedAffinity.ConsumeTurns(turnsModel);
    }

    private void DecreaseCurrentFighterMp()
    {
        int cost = _skillData.Cost;
        IFighterModel user = _table.GetGameState().CurrentFighter;
        user.SetMp(user.GetState().CurrentMp - cost);
    }

    private void IncreaseCurrentPlayerUsedSkills()
    {
        _table.IncreaseCurrentPlayerUsedSkillsCount();
    }

    private IAffinityController GetPrioritizedAffinity()
    {
        var targets = _targets.GetTargets(_table);
        var afffinities = targets.Select(_type.GetAffinityFrom);
        var prioritizedAffinity = afffinities.MaxBy(affinity => affinity.GetPriority())!;
        return prioritizedAffinity;
    }


}