using Shin_Megami_Tensei.Common;
using Shin_Megami_Tensei.Skills;

namespace Shin_Megami_Tensei.Samurais;

public class Samurai
{
    public string Name = "";
    public BaseStats BaseStats = new();
    public Affinities Affinities = new();
    public Skill[] Skills = [];

    public Samurai(string name)
    {
        SamuraiData samuraiData = SamuraiDatabase.Find(name);
        FromData(samuraiData);
    }

    public void AddSkills(string[] skills)
    {
        Skills = skills
            .Select(skill => new Skill(skill))
            .ToArray();
    }

    private void FromData(SamuraiData samuraiData)
    {
        Name = samuraiData.name;
        BaseStats = BaseStats.FromInfo(samuraiData.stats);
        Affinities = Affinities.FromInfo(samuraiData.affinity);
    }

    public new string ToString()
    {
        return $"{Name} ({string.Join<Skill>(",", Skills)})";
    }
}