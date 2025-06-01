using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class GiveUp: IFighterCommand
{

    public void Execute(Table table)
    {
        Player loser = table.GetGameState().CurrentPlayer;
        PlayerView loserView = new PlayerView(loser);
        throw new GameException($"{loserView.GetPlayerNameAndNumber()} se rinde");
    }
}