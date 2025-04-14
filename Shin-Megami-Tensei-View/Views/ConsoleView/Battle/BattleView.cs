using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;

namespace Shin_Megami_Tensei.Battles;

public class BattleView
{
    private readonly View _view;
    private readonly TableView _table;

    public BattleView(Table table, View view)
    {
        _table = new TableView(table);
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

    private void PrintIndent()
    {
        string indent = new('-', 40);
        _view.WriteLine(indent);
    }

    public void PrintWinner()
    {
        WriteLine(_table.GetWinner());
    }

    public void StartRound() =>
        WriteLine($"Ronda de {_table.GetCurrentPlayerName()} " +
                  $"(J{_table.GetCurrentPlayerNumber()+1})");

    public void StartTurn()
    {
        WriteLine(_table.GetCurrentInfo());
        WriteLine(_table.GetCurrentPlayerTurns());
        WriteLine("Orden:\n" + _table.GetCurrentPlayerFightOrder());
    }

    public void EndTurn() =>
        WriteLines([
            "Se han consumido 1 Full Turn(s) y 0 Blinking Turn(s)",
            "Se han obtenido 0 Blinking Turn(s)"
        ]);

    public string ReadLine() => _view.ReadLine();
}