using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei_View.Views;

public interface IAffinityView: IView
{
    public void SetActors(IFighterModel attacker, IFighterModel target);
    public void SetDamageDone(int damageDone);
    public void DisplayEnding();
}