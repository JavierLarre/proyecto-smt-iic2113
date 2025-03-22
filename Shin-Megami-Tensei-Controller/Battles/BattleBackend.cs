using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei.Fighters;
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

    public void StartRound()
    {
        _frontend.StartRound();
        while (!IsRoundDone())
        {
            Fighter nextFighter = _table.NextFighterInOrder();
            _frontend.FighterTurn(nextFighter);
            _table.EndTurn();
        }
        _table.EndRound();
    }
    private bool IsRoundDone() => HasBattleFinished() || _table.IsRoundDone();

    public bool HasBattleFinished()
    {
        return _table.HasTeamLost();
    }

    public void End()
    {
        Team winner = _table.GetWinner();
        _frontend.PrintWinner(winner);
    }
}