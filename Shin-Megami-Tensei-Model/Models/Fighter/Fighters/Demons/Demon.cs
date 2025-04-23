namespace Shin_Megami_Tensei_Model;

public class Demon: AbstractFighter
{
    public override IEnumerable<string> GetFightOptions()
        => [
            "Atacar",
            "Usar Habilidad",
            "Invocar",
            "Pasar Turno"
    ];

    public Demon(string name, Skill[] skills,
        Stats stats, Affinities affinities)
        : base(name, skills, stats, affinities)
    {
    }
}