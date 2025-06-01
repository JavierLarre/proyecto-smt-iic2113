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
    private ConsoleBattleView _view = BattleViewSingleton.GetBattleView();
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
        var targets = _targets.GetTargets();
        foreach (IFighterModel target in targets)
            SingularApplyEffect(target);
        
    }

    private void SingularApplyEffect(IFighterModel target)
    {
        _type.SetTarget(target);
        ITypeView typeView = _type.GetActionView();
        typeView.StartDisplay();
        int hits = _hits.GetHits();
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
        prioritizedAffinity.ConsumeTurns();
    }

    private void DecreaseCurrentFighterMp()
    {
        int cost = _skillData.Cost;
        IFighterModel user = Table.GetInstance().GetCurrentFighter();
        user.SetMp(user.GetCurrentMp() - cost);
    }

    private void IncreaseCurrentPlayerUsedSkills()
    {
        _table.IncreaseCurrentPlayerUsedSkillsCount();
    }

    private IAffinityController GetPrioritizedAffinity()
    {
        IAffinityController prioritizedAffinity = new NeutralAffinity();
        foreach (IFighterModel target in _targets.GetTargets())
        {
            prioritizedAffinity = _type.GetAffinityFrom(target);
            //TODO: implementar prioridad de affinides para ataques multihit
        }

        return prioritizedAffinity;
    }


}