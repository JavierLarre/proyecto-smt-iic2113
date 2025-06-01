namespace Shin_Megami_Tensei_View.Views.ConsoleView.AffinityView;

public class ResistView: NeutralView
{
    public override void Display()
    {
        View.WriteLine($"{Target.GetState().Name} es resistente el ataque de {Attacker.GetState().Name}");
        base.Display();
    }
}