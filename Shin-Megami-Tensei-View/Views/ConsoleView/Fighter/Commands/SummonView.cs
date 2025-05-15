using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView;

public class SummonView: IView
{
    private IFighterModel _summoned;

    public SummonView(IFighterModel summoned) => _summoned = summoned;
    
    public void Display()
    {
        ConsoleBattleView view = BattleViewSingleton.GetBattleView();
        string summonLine = $"{_summoned.GetUnitData().Name} ha sido invocado";
        view.DisplayCard(summonLine);
    }
}