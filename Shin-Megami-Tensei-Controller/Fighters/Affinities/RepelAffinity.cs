using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei.Fighters;

public class RepelAffinity: IAffinityController
{
    public void RecieveAttack(IFighter target, double damage)
    {
        IFighter attacker = Table.GetInstance().GetCurrentFighter();
        attacker.RecieveDamage(damage);
    }

    public void ConsumeTurns()
    {
        Table table = Table.GetInstance();
        TurnManager turnManager = table.GetTurnManager();
        turnManager.ConsumeAll();
    }

    public string GetEffectString(IFighter target, double damage)
    {
        IFighter attacker = Table.GetInstance().GetCurrentFighter();
        IFighterView view = FighterViewFactory.FromFighter(attacker);
        int recievedDamage = Convert.ToInt32(Math.Floor(damage));
        string targetName = target.GetName();
        string repelled = $"{targetName} devuelve {recievedDamage} daño a {view.GetName()}";
        return repelled;
    }
}