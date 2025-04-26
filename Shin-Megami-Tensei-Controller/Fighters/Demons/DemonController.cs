using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Fighters.Actions;

namespace Shin_Megami_Tensei.Fighters.Demons;

public class DemonController: AbstractFighterController
{
    public DemonController(IFighter fighter) : base(fighter)
    {
        
    }

    public override IFighterCommand GetCommand(string commandName)
    {
        return commandName switch
        {
            "Atacar" => new PhysAttack(),
            "Usar Habilidad" => new UseSkill(),
            "Invocar" => new DemonInvoke(),
            "Pasar Turno" => new Pass(),
            _ => throw new ArgumentException("Action Not Found")
        };
    }
}