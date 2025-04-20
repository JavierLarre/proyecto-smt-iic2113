using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Fighters.Actions;

namespace Shin_Megami_Tensei.Fighters;

public abstract class AbstractFighterController: IFighterController
{
    protected IFighter Fighter;

    protected AbstractFighterController(IFighter fighter)
    {
        Fighter = fighter;
    }

    public abstract IFighterCommand GetCommand(string commandName);
}