
namespace Shin_Megami_Tensei.Monsters;

public class Monster
{
    public string Name = "";
    public BaseStats BaseStats = new();
    public Affinities Affinities = new();
    public string[] Skills = [];

    public static Monster FromInfo(MonsterInfo monsterInfo)
    {
        Monster monster = new Monster
        {
            Name = monsterInfo.name,
            BaseStats = BaseStats.FromInfo(monsterInfo.stats),
            Affinities = Affinities.FromInfo(monsterInfo.affinity),
            Skills = monsterInfo.skills.ToArray()
        };
        return monster;
    }
}