using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.AffinityView;

public class RepelView: NeutralView
{
    public override void Display()
    {
        View.WriteLine($"{Target.GetState().Name} devuelve {DamageDone} daño a {Attacker.GetState().Name}");
    }

    public override void DisplayEnding()
    {
        new HpEndsWithLine(Attacker).Display();
    }
}