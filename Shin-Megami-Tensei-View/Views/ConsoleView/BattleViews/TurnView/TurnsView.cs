using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;

public class TurnsView: IView
{
    private TurnsModel _turnManager;
    private ConsoleBattleView _view = BattleViewSingleton.GetBattleView();

    public TurnsView(TurnsModel turnManager)
    {
        _turnManager = turnManager;
    }

    public void Display()
    {
        new TableInfoView().Display();
        DisplayTurnsLeft();
        new FightOrderView().Display();
    }

    private void DisplayTurnsLeft()
    {
        TurnsData turns = _turnManager.GetTurns();
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
        TurnsData turns = _turnManager.GetTurns();
        int consumedFullTurns = turns.ConsumedFull;
        int consumedBlinking = turns.ConsumedBlinking;
        string consumedTurns = $"Se han consumido {consumedFullTurns} Full Turn(s)";
        consumedTurns += $" y {consumedBlinking} Blinking Turn(s)";
        _view.DisplayCard(consumedTurns);
    }

    private void DisplayGainedTurns()
    {
        TurnsData turns = _turnManager.GetTurns();
        int gainedBlinking = turns.GainedBlinking;
        string gainedTurns = $"Se han obtenido {gainedBlinking} Blinking Turn(s)";
        _view.WriteLine(gainedTurns);
    }
}