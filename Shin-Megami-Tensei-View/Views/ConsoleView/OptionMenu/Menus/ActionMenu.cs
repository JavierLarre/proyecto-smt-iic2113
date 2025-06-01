using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class ActionMenu: AbstractOptionsMenu
{
    
    public ActionMenu(IFighterModel fighter)
    {
        foreach (string action in fighter.GetState().FightOptions)
        {
            AddOption(action, action);
        }

        SetHeader($"Seleccione una acción para {fighter.GetState().Name}");
    }

    protected override string GetSeparator() => ": ";
}