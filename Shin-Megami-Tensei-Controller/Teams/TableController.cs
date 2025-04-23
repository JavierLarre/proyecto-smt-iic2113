
using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Fighters;
using Shin_Megami_Tensei.Fighters.Actions;

namespace Shin_Megami_Tensei.Teams;

public class TableController
{
    private readonly Table _table = Table.GetInstance();
    
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

    public void PlayAction(string action)
    {
        var currentController = GetCurrentFighterController();
        IFighterCommand command = currentController.GetCommand(action);
        command.Execute();
    }

    private IFighterController GetCurrentFighterController()
    {
        IFighter current = _table.GetCurrentFighter();
        var controllerFactory = new FighterControllerFactory(current);
        return controllerFactory.GetController();
    }
    
}