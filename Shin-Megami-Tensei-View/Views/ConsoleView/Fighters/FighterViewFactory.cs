using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

public static class FighterViewFactory
{
    public static IFighterView FromFighter(IFighter fighter)
    {
        return fighter switch
        {
            Samurai => new SamuraiView(fighter),
            Demon => new DemonView(fighter),
            _ => throw new NotImplementedException("No view for this fighter")
        };
    }
}