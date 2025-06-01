using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei.Fighters;

public class NeutralAffinity: IAffinityController
{
    private int _damageDone;
    public void RecieveAttack(IFighterModel target, double damage)
    {
        _damageDone = GameConstants.Truncate(damage);
        int targetHp = target.GetState().CurrentHp;
        target.SetHp(targetHp - _damageDone);
    }

    public int GetDamageDone() => _damageDone;

    public void ConsumeTurns()
    {
        Table table = Table.GetInstance();
        TurnsModel turnManager = table.GetTurnManager();
        turnManager.ConsumeTurn();
    }
}