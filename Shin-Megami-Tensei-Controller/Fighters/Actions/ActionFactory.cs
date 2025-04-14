using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Actions;

public static class ActionFactory
{
    public static IAction GetAction(IFighter fighter, string action)
    {
        return action switch
        {
            "Atacar" => new Attack(fighter),
            "Disparar" => new Shoot(fighter),
            "Usar Habilidad" => new UseSkill(),
            "Invocar" => new Invoke(),
            "Pasar Turno" => new Pass(),
            "Rendirse" => new GiveUp(),
            _ => throw new ArgumentException("Action Not Found")
        };
    } 
}