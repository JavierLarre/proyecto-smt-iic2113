using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;

public class TurnsView: IView
{
    private TurnManager _turnManager;
    private BattleView _view = BattleViewSingleton.GetBattleView();

    public TurnsView(TurnManager turnManager)
    {
        _turnManager = turnManager;
    }

    public void Display()
    {
        new TableInfoView().Display();
        DisplayTurnsLeft();
        new FightOrderView().Display();
    }

    private void DisplayTurnsLeft()
    {
        Turns turns = _turnManager.GetTurns();
        int fullTurns = turns.FullTurns;
        int blinkingTurns = turns.BlinkingTurns;
        _view.DisplayCard($"Full Turns: {fullTurns}");
        _view.WriteLine($"Blinking Turns: {blinkingTurns}");
    }

    public void DisplayTurnsGained()
    {
        int consumedFullTurns = _turnManager.GetTurns().ConsumedFull;
        _view.DisplayCard($"Se han consumido {consumedFullTurns}");
    }
}