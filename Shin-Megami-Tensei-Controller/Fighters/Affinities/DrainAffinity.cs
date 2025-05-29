using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei.Fighters;

public class DrainAffinity: IAffinityController
{
    public void RecieveAttack(IFighterModel target, double damage)
    {
        int targetHp = target.GetCurrentHp();
        int healedHp = targetHp + GameConstants.Truncate(damage);
        target.SetHp(healedHp);
    }

    public void ConsumeTurns()
    {
        Table table = Table.GetInstance();
        TurnsModel turnManager = table.GetTurnManager();
        turnManager.ConsumeAll();
    }

    public string GetEffectString(IFighterModel target, double damage)
    {
        IFighterView view = FighterViewFactory.FromFighter(target);
        int absorbed = Convert.ToInt32(Math.Floor(damage));
        string absorbs = $"{view.GetName()} absorbe {absorbed} daño";
        // todo: oye y si mejor uso LA FOKIN VISTA
        return absorbs;
    }
}