using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Fighters.Actions;

namespace Shin_Megami_Tensei.Fighters;

public abstract class AbstractFighterController: IFighterController
{
    protected IFighterModel Fighter;

    protected AbstractFighterController(IFighterModel fighter)
    {
        Fighter = fighter;
    }

    public abstract IFighterCommand GetCommand(string commandName);
}