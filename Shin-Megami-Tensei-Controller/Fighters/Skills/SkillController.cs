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
    private Skill _skill;
    private ISkillType _type;
    private ISkillHits _hits;
    private ISkillTargets _targets;
    private ConsoleBattleView _view = BattleViewSingleton.GetBattleView();

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
        ApplyEffectsOnTargets();
        PrintEffects();
        ConsumeTurns();
        DecreaseCurrentFighterMp();
        IncreaseCurrentPlayerUsedSkills();
    }

    private void ApplyEffectsOnTargets()
    {
        var targets = _targets.GetTargets();
        foreach (IFighter target in targets)
            SingularApplyEffect(target);
        
    }

    private void PrintEffects()
    {
        IFighterView targetView;
        IList<string> effectsMade = [];
        foreach (IFighter target in _targets.GetTargets())
        {
            for (int i = 0; i < _hits.CalculateHits(); i++)
                effectsMade.Add(_type.ToString(target, _skill.Power));

            if (_type is not SpecialSkillType)
            {
                targetView = FighterViewFactory.FromFighter(target);
                effectsMade.Add(targetView.GetHpEndedWith());
            }

            
            if (_type.GetTargetAffinity(target) is RepelAffinity)
            {
                IFighter attacker = Table.GetInstance().GetCurrentFighter();
                effectsMade.RemoveAt(effectsMade.Count-1);
                effectsMade.Add(FighterViewFactory.FromFighter(attacker).GetHpEndedWith());
            }

            _view.DisplayCard(effectsMade);
            // TODO E3: implementar una vista para cada tipo
            // Así evito esto
        }
    }

    private void SingularApplyEffect(IFighter target)
    {
        int hits = _hits.CalculateHits();
        for (int i = 0; i < hits; i++)
        {
            int skillPower = _skill.Power;
            _type.ApplyEffect(target, skillPower);
        }
    }

    private void DecreaseCurrentFighterMp()
    {
        int cost = _skill.Cost;
        IFighter user = Table.GetInstance().GetCurrentFighter();
        user.SetMp(user.GetCurrentMp() - cost);
    }

    private static void IncreaseCurrentPlayerUsedSkills()
    {
        Table table = Table.GetInstance();
        table.IncreaseCurrentPlayerUsedSkillsCount();
    }

    private void ConsumeTurns()
    {
        var prioritizedAffinity = GetPrioritizedAffinity();
        prioritizedAffinity.ConsumeTurns();
    }

    private IAffinityController GetPrioritizedAffinity()
    {
        IAffinityController prioritizedAffinity = new NeutralAffinity();
        foreach (IFighter target in _targets.GetTargets())
        {
            prioritizedAffinity = _type.GetTargetAffinity(target);
            //TODO: implementar prioridad de affinides para ataques multihit
        }

        return prioritizedAffinity;
    }


}