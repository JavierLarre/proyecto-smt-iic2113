using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Fighters.Actions;

namespace Shin_Megami_Tensei.Fighters.Samurais;

public class SamuraiController: AbstractFighterController
{
    public SamuraiController(IFighter fighter): base(fighter)
    {
    }

    public override IFighterCommand GetCommand(string commandName)
    {
        return commandName switch
        {
            "Atacar" => new Attack(Fighter),
            "Disparar" => new Shoot(Fighter),
            "Usar Habilidad" => new UseSkill(Fighter),
            "Invocar" => new Invoke(),
            "Pasar Turno" => new Pass(),
            "Rendirse" => new GiveUp(Fighter),
            _ => throw new ArgumentException("Action Not Found")
        };
    }
}