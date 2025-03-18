using Shin_Megami_Tensei.Common;
using Shin_Megami_Tensei.Skills;

namespace Shin_Megami_Tensei.Samurais;

public class Samurai : AbstractFighter
{
    public Samurai(SamuraiDataFromJson data)
    {
        Name = data.name;
        Stats = Stats.FromData(data.stats);
        Affinities = Affinities.FromData(data.affinity);
    }

    public void SetSkills(string[] skills)
    {
        Skills = skills
            .Where(skill => skill != "")
            .Select(SkillFactory.FromName)
            .ToArray();
    }
}