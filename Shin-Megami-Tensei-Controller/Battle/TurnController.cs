using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;

namespace Shin_Megami_Tensei.Battles;

public class TurnController
{
    private Table _table;
    private TurnsView _turnsView;
    private ActionController _actionController;

    public TurnController(Table table)
    {
        _table = table;
        _actionController = new ActionController(table);
        _turnsView = new TurnsView(_table);
    }

    public void PlayTurn()
    {
        _turnsView.Display();
        _actionController.PlayAction();
        _turnsView.DisplayTurnsConsumedAndGained();
        _table.EndTurn();
    }
}