using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Fighters.Actions;

namespace Shin_Megami_Tensei.Fighters.Samurais;

public class SamuraiCommandFactory: AbstractCommandFactory
{
    protected override AbstractInvoke GetInvoke()
    {
        return new SamuraiInvoke();
    }
}