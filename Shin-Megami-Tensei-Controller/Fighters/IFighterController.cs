using Shin_Megami_Tensei.Fighters.Actions;

namespace Shin_Megami_Tensei.Fighters;

public interface IFighterController
{
    public IFighterCommand GetCommand(string commandName);
}