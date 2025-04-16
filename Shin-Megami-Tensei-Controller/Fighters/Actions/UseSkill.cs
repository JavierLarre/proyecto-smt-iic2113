using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class UseSkill: IAction
{
    private bool _isDone = false;
    public string GetActionName() => "Usar Habilidad";
    public bool IsDone() => _isDone;

    public void Act(Table table, BattleView view)
    {
        string choice;
        try
        {
            choice = view.GetSkillFromUser();
        }
        catch (OptionException e)
        {
            throw new ActionException();
        }

        if (choice == "Cancelar")
            throw new ActionException();
        _isDone = true;
    }

    public void Reset() => _isDone = false;
}