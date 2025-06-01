using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters;

public interface IAffinityController
{
    public void SetTarget(IFighterModel target);
    public void SetDamage(double damage);
    public void RecieveAttack(Table table);
    public void ConsumeTurns(TurnsModel turnsModel);
    public int GetDamageDone();
    public int GetPriority();
}