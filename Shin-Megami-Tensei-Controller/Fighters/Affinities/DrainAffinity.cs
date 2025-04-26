using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei.Fighters;

public class DrainAffinity: IAffinityController
{
    public void RecieveAttack(IFighter target, double damage)
    {
        target.HealDamage(damage);
    }

    public void ConsumeTurns()
    {
        Table table = Table.GetInstance();
        TurnManager turnManager = table.GetTurnManager();
        turnManager.ConsumeAll();
    }

    public string GetEffectString(IFighter target, double damage)
    {
        IFighterView view = FighterViewFactory.FromFighter(target);
        int absorbed = Convert.ToInt32(Math.Floor(damage));
        string absorbs = $"{view.GetName()} absorbe {absorbed} daño";
        return absorbs;
    }
}