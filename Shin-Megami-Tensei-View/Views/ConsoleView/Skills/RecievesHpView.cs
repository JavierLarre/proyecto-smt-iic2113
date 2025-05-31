using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Skills;

public class RecievesHpView: IView
{
    private IFighterModel _target;
    private int _healAmount;

    public RecievesHpView(IFighterModel target, int healAmount)
    {
        _target = target;
        _healAmount = healAmount;
    }
    
    public void Display()
    {
        string recieves = $"{_target.GetState().Name} recibe {_healAmount} de HP";
        BattleViewSingleton.GetBattleView().WriteLine(recieves);
    }
}