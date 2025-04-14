using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei.Fighters;
using Shin_Megami_Tensei.Fighters.Actions;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Battles;

public class BattleController
{
    private TableController _table; //Also works as the game model
    private BattleView _view;

    public BattleController(Table table, View view)
    {
        _table = new TableController(table);
        _view = new BattleView(table, view);
    }

    public void Play()
    {
        try
        {
            while (!HasAnyTeamLost())
                PlayRound();
        }
        catch (GameException e)
        {
            _view.WriteLine(e.Message);
        }
        
        EndGame();
    }

    private void PlayRound()
    {
        _view.StartRound();
        while (!IsRoundDone())
            PlayTurn();
        _table.EndRound();
    }

    private bool IsRoundDone() => HasAnyTeamLost() || _table.DoesCurrentPlayerHasTurnsLeft();
    private bool HasAnyTeamLost() => _table.HasAnyTeamLost();
    private void EndGame()
    {
        _view.PrintWinner();
    }

    private void PlayTurn()
    {
        _view.StartTurn();
        PlayAction();
        _view.EndTurn();
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
            catch (ActionException e)
            {
            }
        }

    }
}