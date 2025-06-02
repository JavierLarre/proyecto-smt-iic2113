using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters;

public class DrainAffinity: AbstractAffinity
{

    public override void RecieveAttack(Table table)
    {
        int targetHp = Target.GetState().CurrentHp;
        int healedHp = GetDamageDone();
        Target.SetHp(targetHp + healedHp);
    }

    public override int GetPriority() => 4;

    public override void ConsumeTurns(TurnsModel turnsModel)
    {
        turnsModel.ConsumeAll();
    }
}