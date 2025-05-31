using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Models.Fighter;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Skills;

public class ReviveView: IView
{
    private IFighterModel _reviver;
    private IFighterModel _revived;

    public ReviveView(IFighterModel reviver, IFighterModel revived)
    {
        _reviver = reviver;
        _revived = revived;
    }

    public void Display()
    {
        ConsoleBattleView view = BattleViewSingleton.GetBattleView();
        FighterState reviverState = _reviver.GetState();
        string heals = $"{reviverState.Name} revive a {_revived.GetState().Name}";
        view.WriteLine(heals);
    }
}