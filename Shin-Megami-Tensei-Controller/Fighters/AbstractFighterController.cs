using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Fighters.Actions;

namespace Shin_Megami_Tensei.Fighters;

public abstract class AbstractFighterController: IFighterController //todo: eliminar clase innecesaria
{

    public  IFighterCommand GetCommand(string commandName)
    {
        Table table = Table.GetInstance();
        return commandName switch
        {
            "Atacar" => new PhysAttack(table),
            "Disparar" => new ShootAttack(table),
            "Usar Habilidad" => new UseSkill(),
            "Invocar" => GetInvoke(),
            "Pasar Turno" => new Pass(),
            "Rendirse" => new GiveUp(),
            _ => throw new ArgumentException("Action Not Found")
        };
    }

    protected abstract AbstractInvoke GetInvoke();
}