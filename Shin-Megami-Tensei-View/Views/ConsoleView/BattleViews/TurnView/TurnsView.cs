using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;

public class TurnsView
{
    private TurnManager _turnManager;
    private BattleView _view = BattleViewSingleton.GetBattleView();

    public TurnsView()
    {
        Table table = Table.GetInstance();
        _turnManager = table.GetTurnManager();
    }
    
    public void DisplayTurnsLeft()
    {
        _view.DisplayCard($"Full Turns: {_turnManager.GetFullTurns()}");
        _view.WriteLine($"Blinking Turns: {_turnManager.GetBlinkingTurns()}");
    }

    public void DisplayTurnsGained()
    {
        
    }
}