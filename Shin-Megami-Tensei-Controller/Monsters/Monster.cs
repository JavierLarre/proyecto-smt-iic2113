using Shin_Megami_Tensei.Common;
using Shin_Megami_Tensei.Skills;

namespace Shin_Megami_Tensei.Monsters;

public class Monster : AbstractFighter
{
    public new Skill[] Skills;

    public Monster(MonsterDataFromJson data)
    {
        Name = data.name;
        Stats = Stats.FromData(data.stats);
        Affinities = Affinities.FromData(data.affinity);
        Skills = data.skills
            .Select(SkillFactory.FromName)
            .ToArray();
    }
}