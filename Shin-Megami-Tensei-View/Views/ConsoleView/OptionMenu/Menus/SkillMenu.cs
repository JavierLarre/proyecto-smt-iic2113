using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class SkillMenu: AbstractOptionsMenu
{
    
    public SkillMenu(IFighterModel fighter)
    {
        var skills = fighter.GetState().UsableSkills;
        foreach (SkillData skill in skills)
        {
            AddOption(skill.Name, skill.ToString());
        }
        AddCancelOption();
        SetHeader($"Seleccione una habilidad para que {fighter.GetState().Name} use");
    }
    protected override string GetSeparator() => "-";
}