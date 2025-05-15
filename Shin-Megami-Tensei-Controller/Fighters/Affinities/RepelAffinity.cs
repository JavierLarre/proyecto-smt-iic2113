using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei.Fighters;

public class RepelAffinity: IAffinityController
{
    public void RecieveAttack(IFighterModel target, double damage)
    {
        IFighterModel attacker = Table.GetInstance().GetCurrentFighter();
        attacker.SetHp(attacker.GetCurrentHp() - Constants.Truncate(damage));
    }

    public void ConsumeTurns()
    {
        Table table = Table.GetInstance();
        TurnsModel turnManager = table.GetTurnManager();
        turnManager.ConsumeAll();
    }

    public string GetEffectString(IFighterModel target, double damage)
    {
        IFighterModel attacker = Table.GetInstance().GetCurrentFighter();
        IFighterView view = FighterViewFactory.FromFighter(attacker);
        int recievedDamage = Convert.ToInt32(Math.Floor(damage));
        string targetName = target.GetUnitData().Name;
        string repelled = $"{targetName} devuelve {recievedDamage} daño a {view.GetName()}";
        return repelled;
    }
}