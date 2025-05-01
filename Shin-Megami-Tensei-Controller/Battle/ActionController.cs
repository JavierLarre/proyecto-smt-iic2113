using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Fighters;
using Shin_Megami_Tensei.Fighters.Actions;

namespace Shin_Megami_Tensei.Battles;

public class ActionController
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
        BattleView view = BattleViewSingleton.GetBattleView();
        string action = view.GetActionFromUser();
        IFighterCommand command = GetCommandFromAction(action);
        command.Execute();
    }

    private IFighterCommand GetCommandFromAction(string action)
    {
        IFighter currentFighter = _table.GetCurrentFighter();
        IFighterController controller = FighterControllerFactory
            .GetController(currentFighter);
        return controller.GetCommand(action);
    }
}