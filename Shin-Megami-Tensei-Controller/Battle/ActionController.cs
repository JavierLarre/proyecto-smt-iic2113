using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views;
using Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Fighters;
using Shin_Megami_Tensei.Fighters.Actions;

namespace Shin_Megami_Tensei.Battles;

public class ActionController: IViewController
{
    private Table _table = Table.GetInstance();
    
    public void PlayAction()
    {
        while (true)
        {
            try
            {
                ExecuteCommandFromUser();
                return;
            }
            catch (FighterCommandException e) { }
            catch (OptionException e) { }
        }
    }

    private void ExecuteCommandFromUser()
    {
        IFighterModel currentFighter = _table.GetCurrentFighter();
        FighterActionsView fighterActionsView = new FighterActionsView(currentFighter, this);
        fighterActionsView.Display();
    }

    private IFighterCommand GetCommandFromAction(string action)
    {
        IFighterModel currentFighter = _table.GetCurrentFighter();
        IFighterController controller = FighterControllerFactory
            .GetController(currentFighter);
        return controller.GetCommand(action);
    }

    public void OnInput(string input)
    {
        IFighterCommand fighterCommand = GetCommandFromAction(input);
        fighterCommand.Execute();
    }
}