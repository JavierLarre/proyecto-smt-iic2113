using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters;

public class DrainAffinity: IAffinityController
{
    private int _healedHp;
    
    public void RecieveAttack(IFighterModel target, double damage)
    {
        int targetHp = target.GetState().CurrentHp;
        _healedHp = GameConstants.Truncate(damage);
        target.SetHp(targetHp + _healedHp);
    }

    public int GetDamageDone() => _healedHp;

    public void ConsumeTurns()
    {
        Table table = Table.GetInstance();
        TurnsModel turnManager = table.GetTurnManager();
        turnManager.ConsumeAll();
    }
}