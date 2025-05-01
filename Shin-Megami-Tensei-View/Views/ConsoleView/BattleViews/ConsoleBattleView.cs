using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;

namespace Shin_Megami_Tensei.Battles;

public class ConsoleBattleView
{
    private readonly View _view;
    private readonly TableInfoView _tableInfoView = new();

    public ConsoleBattleView(View view) => _view = view;

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

    public int GetInputFromUser() => int.Parse(_view.ReadLine());

    private void DisplayIndent()
    {
        string indent = new('-', 40);
        _view.WriteLine(indent);
    }
}