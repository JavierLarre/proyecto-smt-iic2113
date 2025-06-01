using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Fighters;
using Shin_Megami_Tensei_View.Views.ConsoleView;
using Shin_Megami_Tensei_View.Views.ConsoleView.AffinityView;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei_View.Views;

public class AttackView: ITypeView
{
    private IFighterModel _attacker = new EmptyFighter();
    private IFighterModel _target = new EmptyFighter();
    private ConsoleBattleView _view = BattleViewSingleton.GetBattleView();
    private IAffinityView _affinityView = new NeutralView();
    private string _actionMade;
    private int _damageDone;

    public AttackView(string attackType, int damageDone)
    {
        _actionMade = GetActionFromType(attackType);
        _damageDone = damageDone;
    }

    public void StartDisplay()
    {
        _view.DisplayIndent();
    }

    public void Display()
    {
        string attackerName = _attacker.GetState().Name;
        string recieverName = _target.GetState().Name;
        _view.WriteLine($"{attackerName} {_actionMade} a {recieverName}");
        _affinityView.Display();
    }

    public void DisplayEnding()
    {
        _affinityView.DisplayEnding();
    }

    public void SetAffinity(string affinityString)
    {
        _affinityView = affinityString switch
        {
            "Wk" => new WeakView(),
            "Rs" => new ResistView(),
            "Nu" => new NullView(),
            "Rp" => new RepelView(),
            "Dr" => new DrainView(),
            _ => new NeutralView()
        };
        _affinityView.SetActors(_attacker, _target);
        _affinityView.SetDamageDone(_damageDone);
    }

    public void SetActors(IFighterModel attacker, IFighterModel target)
    {
        _attacker = attacker;
        _target = target;
        _affinityView.SetActors(_attacker, _target);
    }

    private static string GetActionFromType(string type)
    {
        return type switch
        {
            "Phys" => "ataca",
            "Gun" => "dispara",
            "Fire" => "lanza fuego",
            "Ice" => "lanza hielo",
            "Elec" => "lanza electricidad",
            "Force" => "lanza viento",
            _ => ""
        };
    }

}