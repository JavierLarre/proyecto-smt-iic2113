using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;

namespace Shin_Megami_Tensei.Battles;

public class TurnController
{
    private Table _table = Table.GetInstance();
    private TurnsView _turnsView;
    private ActionController _actionController = new ();

    public TurnController()
    {
        TurnManager turnManager = _table.GetTurnManager();
        _turnsView = new TurnsView(turnManager);
    }

    public void PlayTurn()
    {
        BattleView view = BattleViewSingleton.GetBattleView();
        _turnsView.Display();
        _actionController.PlayAction();
        view.PrintConsumedAndObtainedTurns();
        _table.EndTurn();
    }
}