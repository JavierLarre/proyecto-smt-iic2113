using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Fighters;
using Shin_Megami_Tensei_View.Views;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei.TargetTypes;

public class SingleEnemyTarget: IViewController
{
    private IFighterModel _cachedTarget = new EmptyFighter();
    private GameState _gameState;

    public SingleEnemyTarget(Table table) => _gameState = table.GetGameState();

    public IFighterModel GetTarget()
    {
        if (_cachedTarget is EmptyFighter)
            InitializeTargetFromUser();
        return _cachedTarget;
    }

    private void InitializeTargetFromUser()
    {
        IFighterModel attacker = _gameState.CurrentFighter;
        var possibleTargets = _gameState.EnemyTeamAliveTargets;
        TargetMenu targetMenu = new TargetMenu(attacker, possibleTargets);
        targetMenu.SetInput(this);
        targetMenu.GetChoice();
    }
    
    public void OnInput(string input)
    {
        var possibleTargets = _gameState.EnemyTeamAliveTargets;
        bool FindByName(IFighterModel fighter)
        {
            return fighter.GetState().Name == input;
        }

        _cachedTarget = possibleTargets.First(FindByName);
    }
}