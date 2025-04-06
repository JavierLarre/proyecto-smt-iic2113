namespace Shin_Megami_Tensei_Model;

public interface IFighter
{
    public string Name { get; }
    public Stats Stats { get; }
    public string[] FightOptions { get; }
    public Skill[] Skills { get; }
    public Affinities Affinities { get; }
}