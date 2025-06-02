using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters;

public class RepelAffinity: AbstractAffinity
{
    public override void RecieveAttack(Table table)
    {
        IFighterModel attacker = table.GetGameState().CurrentFighter;
        int repelledDamage = GetDamageDone();
        attacker.SetHp(attacker.GetState().CurrentHp - repelledDamage);
    }

    public override void ConsumeTurns(TurnsModel turnsModel)
    {
        turnsModel.ConsumeAll();
    }

    public override int GetPriority() => 4;
}