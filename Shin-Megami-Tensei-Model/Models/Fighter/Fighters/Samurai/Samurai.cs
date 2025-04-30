namespace Shin_Megami_Tensei_Model;

public class Samurai: AbstractFighter
{
    public Samurai(UnitData unitData) : base(unitData) { }
    
    public static readonly ICollection<string> FightOptions = [
        "Atacar",
        "Disparar",
        "Usar Habilidad",
        "Invocar",
        "Pasar Turno",
        "Rendirse"
    ];

    public override void AddToReserve(Team team) { }
}