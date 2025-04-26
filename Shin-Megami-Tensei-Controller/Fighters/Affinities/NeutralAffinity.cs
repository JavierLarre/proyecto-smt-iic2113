using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei.Fighters;

public class NeutralAffinity: IAffinityController
{
    public void RecieveAttack(IFighter target, double damage)
    {
        target.RecieveDamage(damage);
    }

    public void ConsumeTurns()
    {
        Table table = Table.GetInstance();
        TurnManager turnManager = table.GetTurnManager();
        turnManager.ConsumeTurn();
    }

    public string GetEffectString(IFighter target, double damage)
    {
        int recievedDamage = Convert.ToInt32(Math.Floor(damage));
        IFighterView view = FighterViewFactory.FromFighter(target);
        string recieved = $"{view.GetName()} recibe {recievedDamage} de daño";
        return recieved;
    }
}