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
    private readonly Table _table = Table.GetInstance();
    private readonly ConsoleBattleView _view = BattleViewSingleton.GetBattleView();

    public void Play()
    {
        RoundController roundController = new RoundController();
        try
        {
            while (HasNoPlayerLost())
            {
                roundController.PlayRound();
            }
        }
        catch (GameException e)
        {
            _view.DisplayCard(e.Message);
        }
        
        new EndGameController().EndGame();
    }

    private bool HasNoPlayerLost() => !_table.HasAnyTeamLost();

}