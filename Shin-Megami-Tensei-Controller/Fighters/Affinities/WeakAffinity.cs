using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei.Fighters;

public class WeakAffinity: IAffinityController
{
    public void RecieveAttack(IFighterModel target, double damage)
    {
        target.SetHp(target.GetCurrentHp() - GameConstants.Truncate(damage * 1.5));
    }

    public void ConsumeTurns()
    {
        Table table = Table.GetInstance();
        TurnsModel turnManager = table.GetTurnManager();
        turnManager.ConsumeFullAndGain();
    }

    public string GetEffectString(IFighterModel target, double damage)
    {
        IFighterModel attacker = Table.GetInstance().GetCurrentFighter();
        FighterView view = new FighterView(target);
        string weaker = $"{view.GetName()} es débil contra el ataque de {attacker.GetUnitData().Name}";
        string recieves = $"{view.GetName()} recibe {Convert.ToInt32(Math.Floor(damage * 1.5))} de daño";
        return weaker + '\n' + recieves;
    }
}