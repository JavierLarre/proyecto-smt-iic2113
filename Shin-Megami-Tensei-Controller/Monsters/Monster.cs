using Shin_Megami_Tensei.Common;
using Shin_Megami_Tensei.Skills;

namespace Shin_Megami_Tensei.Monsters;

public class Monster
{
    public string Name;
    public BaseStats BaseStats;
    public Affinities Affinities;
    public Skill[] Skills;

    public static Monster FromName(string name)
    {
        MonsterDataFromJson data = MonsterDatabase.Find(name);
        return new Monster(data);
    }

    private Monster(MonsterDataFromJson data)
    {
        Name = data.name;
        BaseStats = BaseStats.FromData(data.stats);
        Affinities = Affinities.FromInfo(data.affinity);
        Skills = data.skills
            .Select(Skill.FromName)
            .ToArray();
    }
}