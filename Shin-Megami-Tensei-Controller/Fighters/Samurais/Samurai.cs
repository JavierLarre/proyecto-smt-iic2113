

using Shin_Megami_Tensei.Fighters.Skills;

namespace Shin_Megami_Tensei.Fighters.Samurais;

public class Samurai : Fighter
{
    public Samurai(SamuraiDataFromJson data)
    {
        Name = data.name;
        Stats = new Stats(data.stats);
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