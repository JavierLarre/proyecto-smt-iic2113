namespace Shin_Megami_Tensei_Model;

public class Samurai: AbstractFighter
{
    public override string[] FightOptions =>
    [
        "Atacar",
        "Disparar",
        "Usar Habilidad",
        "Invocar",
        "Pasar Turno",
        "Rendirse"
    ];

    public Samurai(string name, Skill[] skills, Stats stats, Affinities affinities)
        : base(name, skills, stats, affinities)
    {
        
    }
}