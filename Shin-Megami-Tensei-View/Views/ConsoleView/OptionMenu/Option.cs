namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class Option: BaseOption
{
    private readonly string _name;
    public Option(string name) => _name = name;
    public override string ToString() => _name;
}