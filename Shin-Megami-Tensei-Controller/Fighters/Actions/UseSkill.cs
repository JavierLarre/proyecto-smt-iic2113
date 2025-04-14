using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class UseSkill: IAction
{
    private bool _isDone = false;
    public string ActionName() => "Usar Habilidad";
    public bool IsDone() => _isDone;

    public void Act(Table table, BattleView view)
    {
        IFighter attacker = table.GetCurrentFighter();
        SkillsView skills = new SkillsView(attacker.GetAvailableSkills().ToList());
        IOptionMenu targetMenu = OptionFactory.BuildMenu(
            $"Seleccione una habilidad para que {attacker.Name} use",
            "",
            "-",
            skills.ViewSkills(),
            view,
            true
        );
        string target = targetMenu.GetOption().ToString();
        if (target == "Cancelar")
            throw new ActionException();
        _isDone = true;
        
    }

    public void Reset() => _isDone = false;
}