namespace Shin_Megami_Tensei_View.Views.ConsoleView.AffinityView;

public class WeakView: NeutralView
{
    public override void Display()
    {
        View.WriteLine($"{Target.GetState().Name} es débil contra el ataque de {Attacker.GetState().Name}");
        base.Display();
    }
}