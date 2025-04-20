namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public interface IOptionMenu
{
    public IEnumerable<string> GetOptions();
    public string GetOptionFromChoice(int choiceIndex);
    public string GetSeparator();
    public string GetHeader();
}