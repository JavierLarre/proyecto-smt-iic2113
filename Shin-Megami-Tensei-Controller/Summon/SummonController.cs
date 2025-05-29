using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Fighters;
using Shin_Megami_Tensei_View.Views;
using Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Fighters.Actions;

namespace Shin_Megami_Tensei;

public class SummonController: IViewController
{
    private Table _table;
    private GameState _gameState;
    private int _summonPosition;
    private SummonFighterMenu _summonMenu;
    private IFighterModel _choosenTarget = new EmptyFighter();
    private ICollection<IFighterModel> _targets;

    public SummonController(Table table)
    {
        _table = table;
        _gameState = _table.GetGameState();
        _targets = _gameState.Reserve.Where(fighter => fighter.IsAlive()).ToList();
        _summonMenu = new SummonFighterMenu(_targets);
        _summonMenu.SetInput(this);
    }

    public void AskUserForTarget()
    {
        _summonMenu.GetChoice();
    }

    public void SummonAt(int summonPosition)
    {
        _table.Summon(_choosenTarget, summonPosition);
        var summonView = new SummonView(_choosenTarget);
        summonView.Display();
    }

    public void OnInput(string input)
    {
        bool GetFighterByName(IFighterModel fighter)
        {
            return fighter.GetState().Name == input;
        }

        _choosenTarget = _targets.First(GetFighterByName);
    }
}