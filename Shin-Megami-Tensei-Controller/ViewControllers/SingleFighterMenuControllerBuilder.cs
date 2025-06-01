using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei.TargetTypes;

public class SingleFighterMenuControllerBuilder
{
    private Table _table;

    public SingleFighterMenuControllerBuilder(Table table)
    {
        _table = table;
    }

    public SingleFighterMenuController BuildFromAliveEnemyTeam()
    {
        GameState gameState = _table.GetGameState();
        var enemyTeamAliveTargets = gameState
            .EnemyPlayerState
            .TeamState
            .AliveTargets;
        var controller = BuildTargetMenuFromCollection(enemyTeamAliveTargets);
        return controller;
    }

    public SingleFighterMenuController BuildFromAliveCurrentTeam()
    {
        GameState gameState = _table.GetGameState();
        var currentTeamAliveTargets = gameState
            .CurrentPlayerState
            .TeamState
            .AliveTargets;
        var controller = BuildTargetMenuFromCollection(currentTeamAliveTargets);
        return controller;
    }

    private SingleFighterMenuController BuildTargetMenuFromCollection(
        ICollection<IFighterModel> collection)
    {
        GameState gameState = _table.GetGameState();
        IFighterModel currentFighter = gameState.CurrentFighter;
        TargetMenu menu = new TargetMenu(currentFighter, collection);
        var controller = new SingleFighterMenuController(menu);
        controller.SetFighters(collection);
        return controller;
    }
}