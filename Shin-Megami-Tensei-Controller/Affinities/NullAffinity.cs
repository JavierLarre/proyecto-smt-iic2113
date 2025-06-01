using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters;

public class NullAffinity: IAffinityController
{
    public void RecieveAttack(IFighterModel target, double damage)
    {
        
    }

    public void ConsumeTurns()
    {
        Table table = Table.GetInstance();
        TurnsModel turnManager = table.GetTurnManager();
        turnManager.ConsumeTurn();
        turnManager.ConsumeTurn();
    }

    public int GetDamageDone() => 0;
}