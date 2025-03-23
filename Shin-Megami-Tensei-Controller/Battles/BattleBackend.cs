using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei.Fighters;
using Shin_Megami_Tensei.Fighters.Actions;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Battles;

public class BattleBackend
{
    private Table _table; //Also works as the game model
    private BattleFrontend _frontend;

    public BattleBackend(Team[] teams, View view)
    {
        _table = new Table(teams);
        _frontend = new BattleFrontend(_table, view);
    }

    public void Play()
    {
        while (!HasBattleFinished())
            StartRound();
        
        End();
    }

    private void StartRound()
    {
        _frontend.StartRound();
        while (!IsRoundDone())
            PlayTurn();
        _table.EndRound();
    }

    private bool PlayerIsGivingUp(IAction action) =>
        action.GetType() == new GiveUp().GetType();
    private bool IsRoundDone() => HasBattleFinished() || _table.IsRoundDone();
    private bool HasBattleFinished() => _table.HasTeamLost();
    
    private void End()
    {
        _frontend.PrintWinner();
    }

    private void PlayTurn()
    {
        _frontend.StartTurn();
        PlayAction();
        _table.EndTurn();
    }
    
    private void PlayAction()
    {
        Fighter nextFighter = _table.NextFighterInOrder();
        IAction action;
        bool isDone;
        do {
            action = _frontend.ChooseActionFromUser(nextFighter);
            action.Act(_table, nextFighter, _frontend);
            isDone = action.IsDone();
        } while (!isDone);
        action.Reset();
        if(!PlayerIsGivingUp(action))
            _frontend.EndTurn();
    }
}