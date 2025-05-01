using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class SkillMenu: AbstractOptionsMenu
{
    
    public SkillMenu(IFighter fighter)
    {
        var mpLeft = fighter.GetCurrentMp();
        var skills = fighter.GetUnitData().Skills.Where(skill => skill.Cost <= mpLeft);
        foreach (Skill skill in skills)
        {
            AddOption(skill.Name, skill.ToString());
        }
        AddCancelOption();
        SetHeader($"Seleccione una habilidad para que {fighter.GetUnitData().Name} use");
    }
    protected override string GetSeparator() => "-";
}