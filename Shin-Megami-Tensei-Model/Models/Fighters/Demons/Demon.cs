namespace Shin_Megami_Tensei_Model;

public class Demon: AbstractFighter
{
    public Demon(string name, string[] fightOptions,
        Skill[] skills, Stats stats, Affinities affinities)
        : base(name, fightOptions, skills, stats, affinities)
    {
    }
}