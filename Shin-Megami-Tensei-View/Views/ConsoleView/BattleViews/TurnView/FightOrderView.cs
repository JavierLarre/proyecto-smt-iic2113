using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;

public class FightOrderView: IView
{
    private ConsoleBattleView _view = BattleViewSingleton.GetBattleView();
    private IEnumerable<IFighterModel> _fightOrder;

    public FightOrderView(GameState gameState)
    {
        _fightOrder = gameState.FightersInTurnOrder;
    }

    public void Display()
    {
        _view.DisplayCard("Orden:");
        DisplayFighters();
    }

    private void DisplayFighters()
    {
        IFighterModel[] fighters = _fightOrder
            .ToArray();
        for (int i = 0; i < fighters.Length; i++)
        {
            IFighterModel fighter = fighters[i];
            _view.WriteLine($"{i+1}-{fighter.GetState().Name}");
        }
    }
}