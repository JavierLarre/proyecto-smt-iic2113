namespace Shin_Megami_Tensei_View.Views.ConsoleView.AffinityView;

public class DrainView: NeutralView
{
    public override void Display()
    {
        View.WriteLine($"{Target.GetState().Name} absorbe {DamageDone} daño");
    }
}