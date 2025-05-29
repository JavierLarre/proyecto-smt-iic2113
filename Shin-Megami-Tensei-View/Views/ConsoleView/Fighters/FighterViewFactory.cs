using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Fighters;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

public static class FighterViewFactory
{
    public static IFighterView FromFighter(IFighterModel fighter)
    {
        return fighter.GetState().Name switch
        {
            null => new EmptyFighterView(),
            _ => new FighterView(fighter)
        };
    }
}