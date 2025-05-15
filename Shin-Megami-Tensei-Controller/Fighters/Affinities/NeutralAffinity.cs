using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei.Fighters;

public class NeutralAffinity: IAffinityController
{
    public void RecieveAttack(IFighterModel target, double damage)
    {
        int targetHp = target.GetCurrentHp();
        target.SetHp(targetHp - Constants.Truncate(damage));
    }

    public void ConsumeTurns()
    {
        Table table = Table.GetInstance();
        TurnsModel turnManager = table.GetTurnManager();
        turnManager.ConsumeTurn();
    }

    public string GetEffectString(IFighterModel target, double damage)
    {
        int recievedDamage = Convert.ToInt32(Math.Floor(damage));
        IFighterView view = FighterViewFactory.FromFighter(target);
        string recieved = $"{view.GetName()} recibe {recievedDamage} de daño";
        return recieved;
    }
}