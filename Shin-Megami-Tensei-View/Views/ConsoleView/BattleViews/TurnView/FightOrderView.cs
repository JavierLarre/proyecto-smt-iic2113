using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;

public class FightOrderView: IView
{
    private Table _table = Table.GetInstance();
    private BattleView _view = BattleViewSingleton.GetBattleView();
    private IEnumerable<IFighter> _fightOrder;

    public FightOrderView()
    {
        _fightOrder = _table.GetCurrentPlayerFightOrder();
    }

    public void Display()
    {
        _view.DisplayCard("Orden:");
        DisplayFighters();
    }

    private void DisplayFighters()
    {
        IFighter[] fighters = _fightOrder
            .ToArray();
        for (int i = 0; i < fighters.Length; i++)
        {
            IFighter fighter = fighters[i];
            _view.WriteLine($"{i+1}-{fighter.GetUnitData().Name}");
        }
    }
}