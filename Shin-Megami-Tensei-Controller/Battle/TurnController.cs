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
        TurnsModel turnManager = _table.GetTurnManager();
        _turnsView = new TurnsView(turnManager);
    }

    public void PlayTurn()
    {
        _turnsView.Display();
        _actionController.PlayAction();
        _turnsView.DisplayTurnsConsumedAndGained();
        _table.EndTurn();
    }
}