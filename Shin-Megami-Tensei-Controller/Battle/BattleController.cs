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
    private readonly Table _table;
    private readonly ConsoleBattleView _view 
        = BattleViewSingleton.GetBattleView();

    private WinConditionController _winCondition;

    public BattleController(Table table)
    {
        _table = table;
        _winCondition = new WinConditionController(_table);
    }

    public void Play()
    {
        RoundController roundController = new RoundController(_table);
        try
        {
            while (HasNoPlayerWon())
            {
                roundController.PlayRound();
            }
        }
        catch (GameException e)
        {
            _view.DisplayCard(e.Message);
        }
        
        new EndGameController(_table).EndGame();
    }

    private bool HasNoPlayerWon() => !_winCondition.HasAnyTeamWon();

}