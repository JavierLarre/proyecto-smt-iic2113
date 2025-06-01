using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views;
using Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Fighters;
using Shin_Megami_Tensei.Fighters.Actions;

namespace Shin_Megami_Tensei.Battles;

public class ActionController: IViewController
{
    private Table _table;
    private IFighterModel _currentFighter;

    public ActionController(Table table)
    {
        _table = table;
        _currentFighter = _table.GetGameState().CurrentFighter;
    }
    
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

    public void OnInput(string input)
    {
        IFighterCommand fighterCommand = GetCommandFromAction(input);
        fighterCommand.Execute(_table);
    }

    private void ExecuteCommandFromUser()
    {
        _currentFighter = _table.GetGameState().CurrentFighter;
        ActionView actionView = new ActionView(_currentFighter, this);
        actionView.Display();
    }

    private IFighterCommand GetCommandFromAction(string action)
    {
        // Un factory no debe ser tan complicado, verdad?
        CommandFactoryBuilder factoryBuilder = new CommandFactoryBuilder(_table);
        ICommandFactory factory = factoryBuilder.FromFighter(_currentFighter);
        return factory.GetCommand(action);
    }
}