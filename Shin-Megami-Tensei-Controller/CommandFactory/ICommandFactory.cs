using Shin_Megami_Tensei.Fighters.Actions;

namespace Shin_Megami_Tensei.Fighters;

public interface ICommandFactory
{
    public IFighterCommand GetCommand(string commandName);
}