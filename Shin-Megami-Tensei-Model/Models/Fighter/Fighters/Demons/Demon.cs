namespace Shin_Megami_Tensei_Model;

public class Demon: AbstractFighter
{
    public Demon(UnitData unitData) : base(unitData) { }

    public static readonly ICollection<string> FightOptions = [
        "Atacar",
        "Usar Habilidad",
        "Invocar",
        "Pasar Turno"
    ];
}