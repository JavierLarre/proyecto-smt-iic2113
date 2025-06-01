using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei.Fighters;

public class WeakAffinity: AbstractAffinity
{

    public override void ConsumeTurns(TurnsModel turnsModel)
    {
        turnsModel.ConsumeFullAndGain();
    }

    public override int GetDamageDone() => GameConstants.Truncate(Damage * 1.5);
    public override int GetPriority()
    {
        throw new NotImplementedException();
    }
}