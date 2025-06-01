using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Fighters;
using Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.TargetTypes;

namespace Shin_Megami_Tensei;

public class SummonController
{
    private Table _table;
    private IFighterModel _choosenTarget = new EmptyFighter();
    private SingleFighterMenuController _menuController;

    public SummonController(Table table)
    {
        _table = table;
        var gameState = _table.GetGameState();
        var currentTeamAliveReserve = gameState
            .CurrentPlayerState
            .TeamState
            .AliveReserve;
        var summonMenu = new SummonFighterMenu(currentTeamAliveReserve);
        _menuController = new SingleFighterMenuController(summonMenu);
        _menuController.SetFighters(currentTeamAliveReserve);
    }

    public void AskUserForTarget()
    {
        _choosenTarget = _menuController.GetTarget();
    }

    public void SummonAt(IFighterModel summonTarget, int summonPosition)
    {
        _table.Summon(summonTarget, summonPosition);
        var summonView = new SummonView(summonTarget);
        summonView.Display();
    }
    public void SummonAt(int summonPosition)
    {
        SummonAt(_choosenTarget, summonPosition);
    }
}