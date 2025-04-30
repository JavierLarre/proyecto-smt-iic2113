using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class ActionMenu: AbstractOptionsMenu
{
    
    public ActionMenu(IFighter fighter)
    {
        foreach (string action in fighter.GetUnitData().FightOptions)
        {
            AddOption(action, action);
        }

        SetHeader($"Seleccione una acción para {fighter.GetUnitData().Name}");
    }

    public override string GetSeparator() => ": ";
}