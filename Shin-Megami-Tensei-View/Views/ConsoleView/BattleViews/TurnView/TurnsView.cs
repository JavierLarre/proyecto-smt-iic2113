using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;

public class TurnsView: IView
{
    private TurnsModel _turnsModel;
    private ConsoleBattleView _view = BattleViewSingleton.GetBattleView();
    private Table _table;

    public TurnsView(Table table)
    {
        _table = table;
        _turnsModel = _table.GetGameState().TurnsModel;
    }

    public void Display()
    {
        GameState gameState = _table.GetGameState();
        new TableInfoView(gameState).Display();
        DisplayTurnsLeft();
        new FightOrderView(gameState).Display();
    }

    private void DisplayTurnsLeft()
    {
        TurnsData turns = _turnsModel.GetTurnsData();
        int fullTurns = turns.FullTurns;
        int blinkingTurns = turns.BlinkingTurns;
        _view.DisplayCard($"Full Turns: {fullTurns}");
        _view.WriteLine($"Blinking Turns: {blinkingTurns}");
    }

    public void DisplayTurnsConsumedAndGained()
    {
        DisplayConsumedTurns();
        DisplayGainedTurns();
    }

    private void DisplayConsumedTurns()
    {
        TurnsData turns = _turnsModel.GetTurnsData();
        int consumedFullTurns = turns.ConsumedFull;
        int consumedBlinking = turns.ConsumedBlinking;
        string consumedTurns = $"Se han consumido {consumedFullTurns} Full Turn(s)";
        consumedTurns += $" y {consumedBlinking} Blinking Turn(s)";
        _view.DisplayCard(consumedTurns);
    }

    private void DisplayGainedTurns()
    {
        TurnsData turns = _turnsModel.GetTurnsData();
        int gainedBlinking = turns.GainedBlinking;
        string gainedTurns = $"Se han obtenido {gainedBlinking} Blinking Turn(s)";
        _view.WriteLine(gainedTurns);
    }
}