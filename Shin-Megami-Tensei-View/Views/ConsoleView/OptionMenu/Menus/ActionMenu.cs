using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Models.Fighter;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class ActionMenu: AbstractOptionsMenu
{
    
    public ActionMenu(IFighterModel fighter)
    {
        FighterState state = fighter.GetState();
        foreach (string action in state.FightOptions)
        {
            AddOption(action, action);
        }

        SetHeader($"Seleccione una acción para {state.Name}");
    }

    protected override string GetSeparator() => ": ";
}