using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters;

public class ResistAffinity: AbstractAffinity
{

    public override void ConsumeTurns(TurnsModel turnsModel)
    {
        turnsModel.ConsumeTurn();
    }

    public override int GetDamageDone() => GameConstants.Truncate(Damage * 0.5);
    public override int GetPriority() => 0;
}