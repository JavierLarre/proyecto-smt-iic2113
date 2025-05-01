using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;

namespace Shin_Megami_Tensei.Battles;

public class TurnController
{
    private Table _table = Table.GetInstance();
    private TurnManager _turnManager;
    private ActionController _actionController = new ();

    public TurnController()
    {
        _turnManager = _table.GetTurnManager();
    }

    public void PlayTurn()
    {
        BattleView view = BattleViewSingleton.GetBattleView();
        view.StartTurn();
        _actionController.PlayAction();
        view.PrintConsumedAndObtainedTurns();
        _table.EndTurn();
    }
}