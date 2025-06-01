namespace Shin_Megami_Tensei_View.Views.ConsoleView.AffinityView;

public class NullView: NeutralView
{
    public override void Display()
    {
        View.WriteLine($"{Target.GetState().Name} bloquea el ataque de {Attacker.GetState().Name}");
    }
}