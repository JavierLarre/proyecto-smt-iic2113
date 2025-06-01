using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Fighters;

namespace Shin_Megami_Tensei.Fighters;

public abstract class AbstractAffinity: IAffinityController
{
    protected IFighterModel Target = new EmptyFighter();
    protected double Damage;

    public void SetTarget(IFighterModel target) => Target = target;

    public void SetDamage(double damage) => Damage = damage;

    public virtual void RecieveAttack(Table table)
    {
        int currentHp = Target.GetState().CurrentHp;
        int damageDone = GetDamageDone();
        int newHp = currentHp - damageDone;
        Target.SetHp(newHp);
    }
    public abstract void ConsumeTurns(TurnsModel turnsModel);
    public virtual int GetDamageDone() => GameConstants.Truncate(Damage);
    public abstract int GetPriority();
}