using Shin_Megami_Tensei.Common;
using Shin_Megami_Tensei.Skills;

namespace Shin_Megami_Tensei.Samurais;

public class Samurai
{
    public string Name;
    public BaseStats BaseStats;
    public Affinities Affinities;
    public Skill[] Skills = [];

    public static Samurai FromName(string name)
    {
        SamuraiDataFromJson data = SamuraiDatabase.FindByName(name);
        return new Samurai(data);
    }
    
    public void SetSkills(string[] skills)
    {
        Skills = skills
            .Where(skill => skill != "")
            .Select(Skill.FromName)
            .ToArray();
    }

    private Samurai(SamuraiDataFromJson data)
    {
        Name = data.name;
        BaseStats = BaseStats.FromData(data.stats);
        Affinities = Affinities.FromInfo(data.affinity);
    }
}