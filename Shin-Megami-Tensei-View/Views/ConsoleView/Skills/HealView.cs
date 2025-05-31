using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Skills;

public class HealView: IView
{
    private IFighterModel _healer;
    private IFighterModel _healed;

    public HealView(IFighterModel healer, IFighterModel healed)
    {
        _healed = healed;
        _healer = healer;
    }
    
    public void Display()
    {
        string heals = $"{_healer.GetState().Name} cura a {_healed.GetState().Name}";
        BattleViewSingleton.GetBattleView().WriteLine(heals);
    }
}