using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei.Battles;

public class BattleView
{
    private readonly View _view;
    private readonly TableView _tableView = new();

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

    public void StartRound() =>
        DisplayCard($"Ronda de {_tableView.GetCurrentPlayerName()} " +
                  $"(J{_tableView.GetCurrentPlayerNumber()})");

    public void StartTurn()
    {
        DisplayCard(_tableView.GetCurrentInfo());
        DisplayCard(_tableView.GetCurrentPlayerTurns());
        DisplayCard("Orden:\n" + _tableView.GetCurrentPlayerFightOrder());
    }

    public void PrintConsumedAndObtainedTurns()
    {
        TurnManager turnManager = Table.GetInstance().GetTurnManager();
        DisplayCard(turnManager.ToString());
    }

    private int GetInputFromUser() => int.Parse(_view.ReadLine());
    
    //TODO: separar cada menú en su propia clase

    public string GetActionFromUser()
    {
        IFighterView currentFighter = _tableView.GetFighterInTurn();
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