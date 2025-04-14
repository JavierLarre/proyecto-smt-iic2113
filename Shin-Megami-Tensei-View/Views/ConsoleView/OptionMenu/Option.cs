namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class Option: IOptionMenu
{
    private readonly string _name;

    public Option(string name) => _name = name;
    public IOptionMenu GetOption() => this;

    public void SetOptions(IEnumerable<IOptionMenu> options,
        string header, string separator)
    {
    }

    public override string ToString() => _name;
}