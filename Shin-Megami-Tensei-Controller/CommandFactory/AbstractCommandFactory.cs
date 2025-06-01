using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Fighters.Actions;

namespace Shin_Megami_Tensei.Fighters;

public abstract class AbstractCommandFactory: ICommandFactory
{


    public  IFighterCommand GetCommand(string commandName)
    {
        return commandName switch
        {
            "Atacar" => new PhysAttack(),
            "Disparar" => new ShootAttack(),
            "Usar Habilidad" => new UseSkill(),
            "Invocar" => GetInvoke(),
            "Pasar Turno" => new Pass(),
            "Rendirse" => new GiveUp(),
            _ => throw new ArgumentException("Action Not Found")
        };
    }

    protected abstract AbstractInvoke GetInvoke();
}