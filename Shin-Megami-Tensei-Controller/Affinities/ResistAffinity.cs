using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei.Fighters;

public class ResistAffinity: IAffinityController
{
    private int _resistedDamage;
    public void RecieveAttack(IFighterModel target, double damage)
    {
        _resistedDamage = GameConstants.Truncate(damage * 0.5);
        target.SetHp(target.GetState().CurrentHp - _resistedDamage);
    }

    public void ConsumeTurns()
    {
        Table table = Table.GetInstance();
        TurnsModel turnManager = table.GetTurnManager();
        turnManager.ConsumeTurn();
    }

    public int GetDamageDone() => _resistedDamage;
}