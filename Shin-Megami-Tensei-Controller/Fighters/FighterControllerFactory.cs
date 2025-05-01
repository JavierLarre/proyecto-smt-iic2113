using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Fighters.Demons;
using Shin_Megami_Tensei.Fighters.Samurais;

namespace Shin_Megami_Tensei.Fighters;

public static class FighterControllerFactory
{
    public static IFighterController GetController(IFighter fighter)
    {
        return fighter switch
        {
            Demon => new DemonController(fighter),
            Samurai => new SamuraiController(fighter),
            _ => throw new ArgumentException("Fighter Type not found")
        };
    }
}