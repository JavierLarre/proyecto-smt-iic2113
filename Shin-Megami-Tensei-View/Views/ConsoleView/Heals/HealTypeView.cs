using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Fighters;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Skills;

public class HealTypeView: ITypeView
{
    private IFighterModel _caster = new EmptyFighter();
    private IFighterModel _target = new EmptyFighter();
    private bool _wasTargetDead;
    private int _healAmount;

    public HealTypeView(bool wasTargetDead, int healAmount)
    {
        _healAmount = healAmount;
        _wasTargetDead = wasTargetDead;
    }

    public void SetActors(IFighterModel caster, IFighterModel target)
    {
        _caster = caster;
        _target = target;
    }

    public void StartDisplay()
    {
        BattleViewSingleton.GetBattleView().DisplayIndent();
    }

    public void Display()
    {
        IView supportView = 
            _wasTargetDead ? 
                new ReviveView(_caster, _target) : 
                new HealView(_caster, _target);
        supportView.Display();
        new RecievesHpView(_target, _healAmount).Display();
    }

    public void DisplayEnding()
    {
        new HpEndsWithLine(_target).Display();
    }
}