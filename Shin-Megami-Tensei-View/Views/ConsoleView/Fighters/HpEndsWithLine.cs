using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

public class HpEndsWithLine: IView
{
    private IFighterModel _fighter;

    public HpEndsWithLine(IFighterModel fighter)
    {
        _fighter = fighter;
    }

    public void Display()
    {
        ConsoleBattleView view = BattleViewSingleton.GetBattleView();
        IFighterView fighterView = FighterViewFactory.FromFighter(_fighter);
        view.WriteLine(fighterView.GetHpEndedWith());
    }
}