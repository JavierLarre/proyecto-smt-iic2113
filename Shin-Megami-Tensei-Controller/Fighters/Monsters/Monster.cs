using Shin_Megami_Tensei.Fighters.Actions;
using Shin_Megami_Tensei.Fighters.Skills;

namespace Shin_Megami_Tensei.Fighters.Monsters;

public class Monster : Fighter
{
    public Monster(MonsterDataFromJson data)
    {
        Name = data.name;
        Stats = new Stats(data.stats);
        Affinities = Affinities.FromData(data.affinity);
        Skills = data.skills
            .Select(SkillFactory.FromName)
            .ToArray();
        Actions = [
            new Attack(),
            new UseSkill(),
            new Invoke(),
            new Pass()
        ];
    }
}