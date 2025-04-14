namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public interface IOptionMenu
{
    // muejejejjejejejeje composite pattern
    public void SetOptions(IEnumerable<IOptionMenu> options,
        string header, string separator);
    public IOptionMenu GetOption();
    public string ToString();
}