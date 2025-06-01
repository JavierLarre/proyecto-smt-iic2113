using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class GiveUp: IFighterCommand
{
    private Table _table = Table.GetInstance();

    public void Execute()
    {
        Player loser = _table.GetCurrentPlayer();
        PlayerView loserView = new PlayerView(loser);
        throw new GameException($"{loserView.GetPlayerNameAndNumber()} se rinde");
    }
}