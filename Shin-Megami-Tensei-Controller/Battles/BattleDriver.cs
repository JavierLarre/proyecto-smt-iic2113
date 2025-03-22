using Shin_Megami_Tensei_View;
using Shin_Megami_Tensei.Fighters;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Battles;

public class BattleDriver
{
    private Table _table; //Also works as backend
    private BattleFrontend _frontend;
    private int _round = 0;
    private int PlayerTurn => (_round - 1) % Constants.Teams + 1;
    private Team CurrentTeam => _table.GetTeamFromPlayer(PlayerTurn);

    public BattleDriver(Team[] teams, View view)
    {
        _table = new Table(teams);
        _frontend = new BattleFrontend(_table, view);
    }

    public void StartRound()
    {
        _round++;
        //TODO: guardar esta variable para modificarla
        IEnumerable<Fighter> turnOrder = CurrentTeam.TurnOrder().ToList();
        //TODO: estoy seguro que hay una mejor manera de implementar esto
        _frontend.ChangeStatus(CurrentTeam, PlayerTurn);
        _frontend.RoundBanner();
        foreach (var fighter in turnOrder)
        {
            //TODO: cual es la diferencia entre round banner y print round
            _frontend.PrintRound();
            _frontend.FighterTurn(fighter);
            if (HasBattleFinished()) break; //TODO: cambiar a IsROundDone
        }
    }

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