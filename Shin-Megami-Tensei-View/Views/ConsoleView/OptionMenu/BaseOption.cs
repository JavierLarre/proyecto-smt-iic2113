namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public abstract class BaseOption: IOptionMenu
{
    public IOptionMenu GetOption() => this;
    public int GetOptionIndex(IOptionMenu option) => 0;
    public void SetOptions(IEnumerable<IOptionMenu> options)
    {
    }

    public void SetMenuView(string header, string separator)
    {
    }

    public abstract override string ToString();

}