using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Fighters.Demons;
using Shin_Megami_Tensei.Fighters.Samurais;

namespace Shin_Megami_Tensei.Fighters;

public class FighterControllerFactory
{
    private readonly IFighter _fighter;

    public FighterControllerFactory(IFighter fighter)
    {
        _fighter = fighter;
    }

    public IFighterController GetController()
    {
        return _fighter switch
        {
            Demon => new DemonController(_fighter),
            Samurai => new SamuraiController(_fighter),
            _ => throw new ArgumentException("Fighter Type not found")
        };
    }
}