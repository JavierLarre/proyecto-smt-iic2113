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
            "Atacar" => new Attack(),
            "Usar Habilidad" => new UseSkill(),
            "Invocar" => new Invoke(),
            "Pasar Turno" => new Pass(),
            _ => throw new ArgumentException("Action Not Found")
        };
    }
}