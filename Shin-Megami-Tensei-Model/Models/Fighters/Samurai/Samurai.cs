namespace Shin_Megami_Tensei_Model;

public class Samurai: AbstractFighter
{
    public Samurai(string name, string[] fightOptions,
        Skill[] skills, Stats stats, Affinities affinities)
        : base(name, fightOptions, skills, stats, affinities)
    {
    }
}