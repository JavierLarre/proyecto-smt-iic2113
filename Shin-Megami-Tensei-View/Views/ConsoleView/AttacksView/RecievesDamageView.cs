using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Skills;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views;

public class RecievesDamageView: IView
{
    private IFighterModel _target;
    private int _damageDone;

    public RecievesDamageView(IFighterModel target, int damageDone)
    {
        _target = target;
        _damageDone = damageDone;
    }
    
    public void Display()
    {
        ConsoleBattleView view = BattleViewSingleton.GetBattleView();
        string recieves = $"{_target.GetState().Name} recibe {_damageDone} de daño";
        view.WriteLine(recieves);
    }
}