using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Fighters;
using Shin_Megami_Tensei.Fighters.Actions;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Battles;

public class BattleController
{
    private readonly TableController _table = new();
    private readonly BattleView _view = BattleViewSingleton.GetBattleView();

    public void Play()
    {
        try
        {
            while (HasNoPlayerLost())
            {
                PlayRound();
            }
        }
        catch (GameException e)
        {
            _view.WriteLine(e.Message);
        }
        
        new EndGameController().EndGame();
    }

    private void PlayRound()
    {
        _view.StartRound();
        while (!IsRoundDone())
            PlayTurn();
        if (HasNoPlayerLost())
            _table.EndRound();
    }

    private void PlayTurn()
    {
        _view.StartTurn();
        PlayAction();
        _view.PrintConsumedAndObtainedTurns();
        _table.EndTurn();
    }

    private void PlayAction()
    {
        bool done = false;
        while (!done)
        {
            try
            {
                string action = _view.GetActionFromUser();
                _table.PlayAction(action);
                done = true;
            }
            catch (FighterCommandException e)
            {
            }
            catch (OptionException e)
            {
            }
        }

    }

    private bool IsRoundDone() =>  _table.HasAnyTeamLost() || _table.DoesCurrentPlayerHasNoTurnsLeft();

    private bool HasNoPlayerLost() => !_table.HasAnyTeamLost();

}