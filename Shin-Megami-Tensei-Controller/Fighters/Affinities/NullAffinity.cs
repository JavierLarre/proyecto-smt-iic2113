using System.Security.Authentication.ExtendedProtection;
using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei.Fighters;

public class NullAffinity: IAffinityController
{
    public void RecieveAttack(IFighter target, double damage)
    {
        
    }

    public void ConsumeTurns()
    {
        Table table = Table.GetInstance();
        TurnManager turnManager = table.GetTurnManager();
        turnManager.ConsumeTurn();
        turnManager.ConsumeTurn();
    }

    public string GetEffectString(IFighter target, double damage)
    {
        IFighterView view = FighterViewFactory.FromFighter(target);
        IFighter attacker = Table.GetInstance().GetCurrentFighter();
        string blockerName = view.GetName();
        string attackerName = attacker.GetName();
        string blocked = $"{blockerName} bloquea el ataque de {attackerName}";
        return blocked;
    }
}