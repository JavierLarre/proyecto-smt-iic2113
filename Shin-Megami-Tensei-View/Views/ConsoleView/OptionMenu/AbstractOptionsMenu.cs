using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public abstract class AbstractOptionsMenu: IOptionMenu
{
    private readonly List<string> _optionsNames = [];
    private readonly List<string> _optionsDisplays = [];
    private string _header = "";

    public IEnumerable<string> GetOptions()
    {
        return _optionsDisplays;
    }

    protected void AddCancelOption()
    {
        AddOption("Cancelar", "Cancelar");
    }

    public string GetOptionFromChoice(int choiceIndex)
    {
        if (_optionsNames[choiceIndex - 1] == "Cancelar")
            throw new OptionException("Opción Cancelada");
        return _optionsNames[choiceIndex - 1];
    }

    public abstract string GetSeparator();
    public string GetHeader() => _header;
    public string GetChoice()
    {
        ConsoleBattleView view = BattleViewSingleton.GetBattleView();
        view.DisplayCard(GetHeader());
        for (int i = 0; i < _optionsDisplays.Count; i++)
        {
            string option = _optionsDisplays[i];
            string formattedOption = $"{i + 1}{GetSeparator()}{option}";
            view.WriteLine(formattedOption);
        }
        int userInput = view.GetInputFromUser();
        return GetOptionFromChoice(userInput);
    }

    protected void SetHeader(string header) => _header = header;

    protected void AddOption(string name, string display)
    {
        _optionsNames.Add(name);
        _optionsDisplays.Add(display);
    }
}