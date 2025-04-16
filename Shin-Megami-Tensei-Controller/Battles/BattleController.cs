using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei.Fighters;
using Shin_Megami_Tensei.Fighters.Actions;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Battles;

public class BattleController
{
    private readonly TableController _table; //Also works as the game model
    private readonly BattleView _view;

    public BattleController(Table table, View view)
    {
        _table = new TableController(table);
        _view = new BattleView(table, view);
    }

    public void Play()
    {
        try
        {
            while (HasNoPlayerLost())
                PlayRound();
        }
        catch (GameException e)
        {
            _view.WriteLine(e.Message);
        }
        
        _view.PrintWinner();
    }

    private void PlayRound()
    {
        _view.StartRound();
        while (!IsRoundDone())
            PlayTurn();
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
                _table.GetActionFromFighter(_view);
                done = true;
            }
            catch (FighterCommandException e)
            {
            }
        }

    }

    private bool IsRoundDone() =>  _table.HasAnyTeamLost() || _table.DoesCurrentPlayerHasNoTurnsLeft();

    private bool HasNoPlayerLost() => !_table.HasAnyTeamLost();

}