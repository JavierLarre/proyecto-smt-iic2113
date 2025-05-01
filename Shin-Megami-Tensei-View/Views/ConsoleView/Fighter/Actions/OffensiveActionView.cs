using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views.ConsoleView;

public abstract class OffensiveActionView: IView
{
    private IFighter _attacker = Table.GetInstance().GetCurrentFighter();
    private IFighter _target;
    private string _actionMade = "";
    private string _extraLine = "";
    private string _result = "";
    private int _hits;

    protected OffensiveActionView(IFighter target, int hits, int recievedDamage)
    {
        _target = target;
        _hits = hits;
    }

    protected IFighter GetAttacker() => _attacker;
    protected IFighter GetTarget() => _target;
    protected void SetActionMade(string line) => _actionMade = line;
    protected void SetResult(string line) => _result = line;
    public void SetExtraLine(string line) => _extraLine = line;

    protected virtual string GetEndedHp()
    {
        return FighterViewFactory.FromFighter(_target).GetHpEndedWith();
    }

    protected virtual string GetRecieverString()
    {
        return $"{_target.GetUnitData().Name} recibe de daño";
    }

    public void Display()
    {
        BattleView view = BattleViewSingleton.GetBattleView();
        List<string> lines =
        [
            $"{_attacker.GetUnitData().Name} {_actionMade} {_target.GetUnitData().Name}"
        ];
        if (_extraLine != "")
            lines.Add(_extraLine);
        lines.Add(_result);
        
        for (int i = 1; i < _hits; i++)
        {
            lines = lines.Concat(lines).ToList();
        }

        view.DisplayCard(lines);
    }
}