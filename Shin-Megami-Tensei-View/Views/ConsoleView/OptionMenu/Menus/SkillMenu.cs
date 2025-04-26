using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class SkillMenu: AbstractOptionsMenu
{
    
    public SkillMenu(IFighter fighter)
    {
        var skills = fighter.GetAvailableSkills();
        foreach (Skill skill in skills)
        {
            AddOption(skill.Name, skill.ToString());
        }
        AddCancelOption();
        SetHeader($"Seleccione una habilidad para que {fighter.GetName()} use");
    }
    public override string GetSeparator() => "-";
}