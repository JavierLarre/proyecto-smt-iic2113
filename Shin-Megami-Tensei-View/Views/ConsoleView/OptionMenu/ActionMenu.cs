using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class ActionMenu: AbstractOptionsMenu
{
    private string _header;
    
    public ActionMenu(IFighter fighter)
    {
        foreach (string action in fighter.FightOptions)
        {
            AddOption(action, action);
        }

        _header = $"Seleccione una acción para {fighter.Name}";
    }

    public override string GetSeparator() => ": ";
    public override string GetHeader() => _header;
}