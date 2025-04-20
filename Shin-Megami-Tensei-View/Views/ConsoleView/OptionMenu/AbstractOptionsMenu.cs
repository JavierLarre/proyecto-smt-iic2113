namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public abstract class AbstractOptionsMenu: IOptionMenu
{
    private readonly List<string> _optionsNames = [];
    private readonly List<string> _optionsDisplays = [];

    public IEnumerable<string> GetOptions()
    {
        return _optionsDisplays;
    }

    public string GetOptionFromChoice(int choiceIndex)
    {
        if (_optionsNames[choiceIndex - 1] == "Cancelar")
            throw new OptionException("Opción Cancelada");
        return _optionsNames[choiceIndex - 1];
    }

    public abstract string GetSeparator();
    public abstract string GetHeader();

    protected void AddOption(string name, string display)
    {
        _optionsNames.Add(name);
        _optionsDisplays.Add(display);
    }
}