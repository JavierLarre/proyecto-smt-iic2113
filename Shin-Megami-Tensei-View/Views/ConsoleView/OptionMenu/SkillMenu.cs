using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class SkillMenu: AbstractOptionsMenu
{
    private string _header;
    
    public SkillMenu(IFighter fighter)
    {
        var skills = fighter.GetAvailableSkills();
        foreach (Skill skill in skills)
        {
            AddOption(skill.Name, skill.ToString());
        }
        AddOption("Cancelar", "Cancelar");
        _header = $"Seleccione una habilidad para que {fighter.Name} use";
    }

    public override string GetHeader() => _header;
    public override string GetSeparator() => "-";
}