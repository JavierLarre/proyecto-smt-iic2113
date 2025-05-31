using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Models.Fighter;
using Shin_Megami_Tensei_View.Views;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei_View.Views.ConsoleView.Skills;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public abstract class SupportiveSkillType: ISkillType
{
    private bool _wasDead;
    private int _healAmount;
    public void ApplyEffect(IFighterModel target, int power)
    {
        _wasDead = !target.GetState().IsAlive;
        double healAmount = CalculateHealAmount(target, power);
        int targetHp = target.GetCurrentHp();
        _healAmount = GameConstants.Truncate(healAmount);
        target.SetHp(targetHp + _healAmount);
    }

    protected static double CalculateHealAmount(IFighterModel target, int power)
    {
        return target.GetUnitData().Stats.Hp * power * 0.01;
    }

    public IAffinityController GetTargetAffinity(IFighterModel target)
    {
        return new NeutralAffinity();
    }

    public abstract string ToString(IFighterModel target, int power);

    public void Display(IFighterModel caster, IFighterModel target)
    {
        IView supportView = 
            _wasDead ? 
            new ReviveView(caster, target) : 
            new HealView(caster, target);
        supportView.Display();
        new RecievesHpView(target, _healAmount).Display();
        new HpEndsWithLine(target).Display();
    }
}