using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public abstract class AbstractOptionsMenu: IOptionMenu
{
    private readonly List<string> _optionsNames = [];
    private readonly List<string> _optionsDisplays = [];
    private string _header = "";
    private IViewController _inputController = new EmptyViewController();

    public void Display()
    {
        ConsoleBattleView view = BattleViewSingleton.GetBattleView();
        view.DisplayCard(_header);
        for (int i = 0; i < _optionsDisplays.Count; i++)
        {
            string option = _optionsDisplays[i];
            string formattedOption = $"{i + 1}{GetSeparator()}{option}";
            view.WriteLine(formattedOption);
        }
    }
    
    public string GetChoice()
    {
        Display();
        string userInput = GetOptionFromChoice();
        OnInput(userInput);
        return userInput;
    }
    
    private string GetOptionFromChoice()
    {
        ConsoleBattleView view = BattleViewSingleton.GetBattleView();
        int choiceIndex = view.GetInputFromUser();
        if (_optionsNames[choiceIndex - 1] == "Cancelar")
            throw new OptionException("Opción Cancelada");
        return _optionsNames[choiceIndex - 1];
    }

    protected abstract string GetSeparator();

    protected void SetHeader(string header) => _header = header;

    protected void AddOption(string name, string display)
    {
        _optionsNames.Add(name);
        _optionsDisplays.Add(display);
    }

    protected void AddCancelOption()
    {
        AddOption("Cancelar", "Cancelar");
    }

    public void OnInput(string input)
    {
        _inputController.OnInput(input);
    }

    public void SetInput(IViewController viewController)
    {
        _inputController = viewController;
    }
}