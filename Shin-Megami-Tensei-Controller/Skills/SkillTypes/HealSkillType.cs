using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Fighters;
using Shin_Megami_Tensei_View.Views;
using Shin_Megami_Tensei_View.Views.ConsoleView;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei_View.Views.ConsoleView.Skills;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class HealSkillType: ISkillType
{
    private bool _wasTargetDead;
    private int _healAmount;
    private IFighterModel _target = new EmptyFighter();
    private IFighterModel _caster = new EmptyFighter();
    private SkillData _skillData;
    
    public HealSkillType(SkillData skillData)
    {
        _skillData = skillData;
    }

    public void SetTarget(IFighterModel target)
    {
        _target = target;
        _wasTargetDead = !target.GetState().IsAlive;
    }
    
    public void ApplyEffect(Table table)
    {
        _caster = table.GetGameState().CurrentFighter;
        _healAmount = CalculateHealAmount();
        int targetHp = _target.GetState().CurrentHp;
        _target.SetHp(targetHp + _healAmount);
    }

    public void SetCaster(IFighterModel caster)
    {
        _caster = caster;
    }

    public void Display()
    {
        IView supportView = 
            _wasTargetDead ? 
            new ReviveView(_caster, _target) : 
            new HealView(_caster, _target);
        supportView.Display();
        new RecievesHpView(_target, _healAmount).Display();
        new HpEndsWithLine(_target).Display();
    }

    public IAffinityController GetAffinityFrom(IFighterModel target)
    {
        return new NeutralAffinity();
    }

    public ITypeView GetActionView()
    {
        HealTypeView healTypeView = new HealTypeView(_wasTargetDead, _healAmount);
        healTypeView.SetActors(_caster, _target);
        return healTypeView;
    }

    private int CalculateHealAmount()
    {
        double healPercetage = _skillData.Power * 0.01;
        double healedAmount = _target.GetState().MaxHp * healPercetage;
        return GameConstants.Truncate(healedAmount);
    }
}