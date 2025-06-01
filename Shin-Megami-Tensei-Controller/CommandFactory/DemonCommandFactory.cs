using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Fighters.Actions;

namespace Shin_Megami_Tensei.Fighters.Demons;

public class DemonCommandFactory: AbstractCommandFactory
{

    protected override AbstractInvoke GetInvoke()
    {
        return new DemonInvoke();
    }
}