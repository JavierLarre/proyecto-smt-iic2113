using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei.Fighters;

public class WeakAffinity: IAffinityController
{
    private int _increasedDamage;
    public void RecieveAttack(IFighterModel target, double damage)
    {
        _increasedDamage = GameConstants.Truncate(damage * 1.5);
        target.SetHp(target.GetState().CurrentHp - _increasedDamage);
    }

    public void ConsumeTurns()
    {
        Table table = Table.GetInstance();
        TurnsModel turnManager = table.GetTurnManager();
        turnManager.ConsumeFullAndGain();
    }

    public int GetDamageDone() => _increasedDamage;
}