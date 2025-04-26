using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters;

public interface IAffinityController
{
    public void RecieveAttack(IFighter target, double damage);
    public void ConsumeTurns();
    public string GetEffectString(IFighter target, double damage);
}