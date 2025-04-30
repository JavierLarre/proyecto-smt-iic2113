using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView;

public class SummonView: IView
{
    private IFighter _summoned;

    public SummonView(IFighter summoned) => _summoned = summoned;
    
    public void Display()
    {
        BattleView view = BattleViewSingleton.GetBattleView();
        string summonLine = $"{_summoned.GetUnitData().Name} ha sido invocado";
        view.WriteLine(summonLine);
    }
}