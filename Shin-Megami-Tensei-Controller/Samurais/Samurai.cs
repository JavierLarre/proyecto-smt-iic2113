namespace Shin_Megami_Tensei.Samurais;

public class Samurai
{
    public string Name = "";
    public BaseStats BaseStats = new BaseStats();
    public Affinities Affinities = new Affinities();

    public static Samurai FromInfo(SamuraiInfo samuraiInfo)
    {
        Samurai samurai = new Samurai
        {
            Name = samuraiInfo.Name,
            BaseStats = BaseStats.FromInfo(samuraiInfo.StatsInfo),
            Affinities = Affinities.FromInfo(samuraiInfo.AffinityInfo),
        };
        return samurai;
    }
}