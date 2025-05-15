using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.BattleViews;

public class ActionView: IViewInput
{
    private IFighterModel _currentFighter;
    private IViewController _controller;

    public ActionView(IFighterModel currentFighter, IViewController controller)
    {
        _currentFighter = currentFighter;
        _controller = controller;
    }

    public void Display()
    {
        IFighterView fighterView = FighterViewFactory
            .FromFighter(_currentFighter);
        IOptionMenu actionMenu = fighterView.GetActionsMenu();
        string choice = actionMenu.GetChoice();
        OnInput(choice);
    }

    public void OnInput(string input)
    {
        _controller.OnInput(input);
    }

    public void SetInput(IViewController viewController)
    {
        _controller = viewController;
    }
}