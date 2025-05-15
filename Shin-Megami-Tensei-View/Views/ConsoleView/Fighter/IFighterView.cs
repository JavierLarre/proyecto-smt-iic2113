using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

public interface IFighterView
{
    public IFighterModel GetFighter();
    public string GetName();
    public string GetStats();
    public string GetInfo();
    public IOptionMenu GetActionsMenu();
    public string GetHpEndedWith();
}