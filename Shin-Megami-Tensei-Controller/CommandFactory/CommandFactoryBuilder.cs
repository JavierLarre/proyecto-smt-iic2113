using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Fighters.Demons;
using Shin_Megami_Tensei.Fighters.Samurais;

namespace Shin_Megami_Tensei.Fighters;

public class CommandFactoryBuilder
{
    private Table _table;

    public CommandFactoryBuilder(Table table)
    {
        _table = table;
    }
    public ICommandFactory FromFighter(IFighterModel fighter)
    {
        return fighter switch
        {
            Demon => new DemonCommandFactory(),
            Samurai => new SamuraiCommandFactory(),
            _ => throw new ArgumentException("Fighter Type not found")
        };
    }
}