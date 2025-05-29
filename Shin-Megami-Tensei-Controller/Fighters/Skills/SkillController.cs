using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
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
        PrintEffects();
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

    private void PrintEffects()
    {
        IList<string> effectsMade = [];
        foreach (IFighterModel target in _targets.GetTargets())
        {
            for (int i = 0; i < _hits.CalculateHits(); i++)
                effectsMade.Add(_type.ToString(target, _skillData.Power));

            var targetView = new FighterView(target);
            effectsMade.Add(targetView.GetHpEndedWith());
            if (_type.GetTargetAffinity(target) is RepelAffinity)
            {
                IFighterModel attacker = Table.GetInstance().GetCurrentFighter();
                effectsMade.RemoveAt(effectsMade.Count-1);
                effectsMade.Add(new FighterView(attacker).GetHpEndedWith());
            }

            _view.DisplayCard(effectsMade);
            // TODO E3: implementar una vista para cada tipo
            // Así evito esto
        }
    }

    private void SingularApplyEffect(IFighterModel target)
    {
        int hits = _hits.CalculateHits();
        for (int i = 0; i < hits; i++)
        {
            int skillPower = _skillData.Power;
            _type.ApplyEffect(target, skillPower);
        }
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

    private void ConsumeTurns()
    {
        var prioritizedAffinity = GetPrioritizedAffinity();
        prioritizedAffinity.ConsumeTurns();
    }

    private IAffinityController GetPrioritizedAffinity()
    {
        IAffinityController prioritizedAffinity = new NeutralAffinity();
        foreach (IFighterModel target in _targets.GetTargets())
        {
            prioritizedAffinity = _type.GetTargetAffinity(target);
            //TODO: implementar prioridad de affinides para ataques multihit
        }

        return prioritizedAffinity;
    }


}