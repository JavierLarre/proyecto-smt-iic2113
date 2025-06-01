using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters;

public class NullAffinity: AbstractAffinity
{
    public override void RecieveAttack(Table table) { }

    public override void ConsumeTurns(TurnsModel turnsModel)
    {
        turnsModel.ConsumeTurn();
        turnsModel.ConsumeTurn();
    }

    public override int GetDamageDone() => 0;
    public override int GetPriority()
    {
        throw new NotImplementedException();
    }
}