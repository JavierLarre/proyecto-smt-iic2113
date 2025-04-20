using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class GiveUp: IFighterCommand
{
    private IFighter _fighter;
    public GiveUp(IFighter fighter)
    {
        _fighter = fighter;
    }

    public void Execute(Table table, BattleView view)
    {
        PlayerView loser = new PlayerView(table.GetCurrentPlayer());
        throw new GameException($"{loser.GetPlayerName()} (J{loser.GetPlayerNumber()}) se rinde");
    }
}