using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters;

public class NeutralAffinity: AbstractAffinity
{
    public override int GetPriority()
    {
        throw new NotImplementedException();
    }

    public override void ConsumeTurns(TurnsModel turnsModel)
    {
        turnsModel.ConsumeTurn();
    }
}