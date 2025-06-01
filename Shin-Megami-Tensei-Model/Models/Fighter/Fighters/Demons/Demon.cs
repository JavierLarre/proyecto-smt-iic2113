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

    public override void AddToReserve(Team team)
    {
        team.MoveToReserve(this);
    }

    protected override bool CanBeSwapped() => true;
}