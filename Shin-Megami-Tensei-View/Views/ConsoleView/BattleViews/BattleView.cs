using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei.Battles;

public class BattleView
{
    private readonly View _view;
    private readonly TableInfoView _tableInfoView = new();

    public BattleView(View view) => _view = view;

    public void DisplayCard(IEnumerable<string> lines)
    {
        DisplayIndent();
        foreach (var line in lines)
            _view.WriteLine(line);
    }

    public void DisplayCard(string line)
    {
        DisplayIndent();
        _view.WriteLine(line);
    }

    public void WriteLine(string line) => _view.WriteLine(line);

    private int GetInputFromUser() => int.Parse(_view.ReadLine());

    public string GetActionFromUser()
    {
        IFighterView currentFighter = _tableInfoView.GetFighterInTurn();
        IOptionMenu actionMenu = currentFighter.GetActionsMenu();
        return GetChoiceFromOptionMenu(actionMenu);
    }


    public string GetChoiceFromOptionMenu(IOptionMenu menu)
    {
        var numberedOptions = menu.GetOptions()
            .Select((option, i) => $"{i+1}{menu.GetSeparator()}{option}");
        string formattedOptions = string.Join('\n', numberedOptions);
        DisplayCard(menu.GetHeader() + '\n' + formattedOptions);
        int userChoice = GetInputFromUser();
        return menu.GetOptionFromChoice(userChoice);
    }

    private void DisplayIndent()
    {
        string indent = new('-', 40);
        _view.WriteLine(indent);
    }
}