using Shin_Megami_Tensei.Common;
using Shin_Megami_Tensei.Skills;

namespace Shin_Megami_Tensei.Monsters;

public class Monster
{
    public string Name = "";
    public BaseStats BaseStats = new();
    public Affinities Affinities = new();
    public Skill[] Skills = [];

    public void FromData(MonsterData monsterData)
    {
        Name = monsterData.name;
        BaseStats = BaseStats.FromInfo(monsterData.stats);
        Affinities = Affinities.FromInfo(monsterData.affinity);
        Skills = monsterData.skills
            .Select(skill => new Skill(skill))
            .ToArray();
    }

    public Monster(string name)
    {
        MonsterData data = MonsterDatabase.Find(name);
        FromData(data);
    }
}