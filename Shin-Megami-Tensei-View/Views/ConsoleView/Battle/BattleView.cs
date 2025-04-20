using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei.Battles;

public class BattleView
{
    private readonly View _view;
    private readonly TableView _tableView;

    public BattleView(Table table, View view)
    {
        _tableView = new TableView(table);
        _view = view;
    }

    public void WriteLines(IEnumerable<string> lines)
    {
        PrintIndent();
        foreach (var line in lines)
            _view.WriteLine(line);
    }

    public void WriteLine(string line)
    {
        PrintIndent();
        _view.WriteLine(line);
    }

    public void PrintWinner()
    {
        WriteLine(_tableView.GetWinner());
    }

    public void StartRound() =>
        WriteLine($"Ronda de {_tableView.GetCurrentPlayerName()} " +
                  $"(J{_tableView.GetCurrentPlayerNumber()})");

    public void StartTurn()
    {
        WriteLine(_tableView.GetCurrentInfo());
        WriteLine(_tableView.GetCurrentPlayerTurns());
        WriteLine("Orden:\n" + _tableView.GetCurrentPlayerFightOrder());
    }

    public void PrintConsumedAndObtainedTurns()
    {
        string consumed = $"Se han consumido 1 Full Turn(s)"
                          + $" y 0 Blinking Turn(s)";
        string gained = $"Se han obtenido 0 Blinking Turn(s)";
        WriteLine(consumed + '\n' + gained);
    }

    public int GetInputFromUser() => int.Parse(_view.ReadLine());
    
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
        WriteLine(menu.GetHeader() + '\n' + formattedOptions);
        int userChoice = GetInputFromUser();
        return menu.GetOptionFromChoice(userChoice);
    }

    private void PrintIndent()
    {
        string indent = new('-', 40);
        _view.WriteLine(indent);
    }
}