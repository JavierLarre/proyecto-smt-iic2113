
using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Fighters.Actions;

namespace Shin_Megami_Tensei.Teams;

public class TableController
{
    private readonly Table _table;

    public TableController(Table table)
    {
        _table = table;
    }
    
    public void EndRound()
    {
        _table.EndRound();
    }

    public void EndTurn()
    {
        _table.EndTurn();
    }


    public bool HasAnyTeamLost()
    {
        return _table.HasAnyTeamLost();
    }

    public bool DoesCurrentPlayerHasNoTurnsLeft()
    {
        return _table.GetFullTurnsLeftFromCurrentPlayer() == 0
            && _table.GetBlinkingTurnsLeftFromCurrentPlayer() == 0;
    }

    public void GetActionFromFighter(BattleView view)
    {
        string choosenAction = view.GetActionFromUser();
        CommandFactory factory = new CommandFactory(_table, view);
        IFighterCommand selection = factory.GetAction(choosenAction);
        selection.Execute();
    }
    
}