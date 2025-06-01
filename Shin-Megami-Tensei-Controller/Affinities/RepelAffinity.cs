using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei.Fighters;

public class RepelAffinity: IAffinityController
{
    private int _repelledDamage;
    public void RecieveAttack(IFighterModel target, double damage)
    {
        Table table = Table.GetInstance();
        IFighterModel attacker = table.GetGameState().CurrentFighter;
        _repelledDamage = GameConstants.Truncate(damage);
        attacker.SetHp(attacker.GetState().CurrentHp - _repelledDamage);
    }

    public void ConsumeTurns()
    {
        Table table = Table.GetInstance();
        TurnsModel turnManager = table.GetTurnManager();
        turnManager.ConsumeAll();
    }

    public int GetDamageDone() => _repelledDamage;
}