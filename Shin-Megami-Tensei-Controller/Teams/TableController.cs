
using Shin_Megami_Tensei_Model;
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
        _table.SwapPlayers();
        _table.CurrentPlayer.Team.ResetTurns();
    }

    public void EndTurn()
    {
        _table.EndTurn();
    }


    public bool HasAnyTeamLost()
    {
        var frontRow = _table.GetCurrentFighters();
        return frontRow.All(fighter => fighter.Stats.HpLeft == 0)
            || !_table.GetEnemyTeamTargets().Any();
        // TODO: investigar porqué funciona
    }

    public bool DoesCurrentPlayerHasTurnsLeft()
    {
        return _table.GetFullTurnsLeftFromCurrentPlayer() == 0
            && _table.GetBlinkingTurnsLeftFromCurrentPlayer() == 0;
    }

    public void GetActionFromFighter(BattleView view)
    {
        IFighter currentFighter = _table.GetCurrentFighter();
        IOptionMenu actionMenu = OptionFactory.BuildMenu(
            $"Seleccione una acción para {currentFighter.Name}",
            "",
            ": ",
            currentFighter.FightOptions,
            view,
            false
        );
        string choosenAction = actionMenu.GetOption().ToString();
        IAction selection = ActionFactory.GetAction(currentFighter, choosenAction);
        selection.Act(_table, view);
    }
    
}