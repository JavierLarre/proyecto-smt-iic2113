using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Models.Fighter;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;

public class SummonView: IView
{
    private ConsoleBattleView _view = BattleViewSingleton.GetBattleView();
    private FighterState _fighterState;

    public SummonView(IFighterModel summonedFighter)
    {
        _fighterState = summonedFighter.GetState();
    }

    public void Display()
    {
        _view.DisplayCard($"{_fighterState.Name} ha sido invocado");
    }
}