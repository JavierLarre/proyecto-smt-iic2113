using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei.Fighters;

public class ResistAffinity: IAffinityController
{
    public void RecieveAttack(IFighter target, double damage)
    {
        target.RecieveDamage(damage * 0.5);
    }

    public void ConsumeTurns()
    {
        Table table = Table.GetInstance();
        TurnManager turnManager = table.GetTurnManager();
        turnManager.ConsumeTurn();
    }

    public string GetEffectString(IFighter target, double damage)
    {
        IFighter attacker = Table.GetInstance().GetCurrentFighter();
        string attackerName = attacker.GetName();
        IFighterView view = FighterViewFactory.FromFighter(target);
        int recievedDamage = Convert.ToInt32(Math.Floor(damage * 0.5));
        string resists = $"{view.GetName()} es resistente el ataque de {attackerName}";
        string recieves = $"{view.GetName()} recibe {recievedDamage} de daño";
        return resists + '\n' + recieves;
    }
}