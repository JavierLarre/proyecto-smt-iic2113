using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Fighters;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.AffinityView;

public class NeutralView: IAffinityView
{
    protected ConsoleBattleView View = BattleViewSingleton.GetBattleView();
    protected IFighterModel Attacker = new EmptyFighter();
    protected IFighterModel Target = new EmptyFighter();
    protected int DamageDone;

    public void SetActors(IFighterModel attacker, IFighterModel target)
    {
        Attacker = attacker;
        Target = target;
    }

    public void SetDamageDone(int damageDone)
    {
        DamageDone = damageDone;
    }

    public virtual void Display()
    {
        ConsoleBattleView view = BattleViewSingleton.GetBattleView();
        view.WriteLine($"{Target.GetState().Name} recibe {DamageDone} de daño");
    }

    public virtual void DisplayEnding()
    {
        new HpEndsWithLine(Target).Display();
    }
}