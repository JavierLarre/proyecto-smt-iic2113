namespace Shin_Megami_Tensei_Model;

public class SamuraiFactory: AbstractFighterFactory
{
    private const string JsonFile = "samurai.json";
    private readonly ICollection<SamuraiDataFromJson> _data = GetData();

    private static ICollection<SamuraiDataFromJson> GetData()
    {
        return JsonDeserializer.Deserialize<SamuraiDataFromJson>(JsonFile);
    }
    
    private SamuraiDataFromJson FindDataByName(string name) =>
        _data.First(samurai => samurai.name == name);

    public IFighter FromNameAndSkills(string name, string[] skills)
    {
        SamuraiDataFromJson samuraiData = FindDataByName(name);
        UnitData unitData = new UnitData()
        {
            Affinities = BuildAffinitiesFrom(samuraiData.affinity),
            Stats = BuildStatsFrom(samuraiData.stats),
            Name = samuraiData.name,
            Skills = GetSkillsFromNames(skills),
            FightOptions = Samurai.FightOptions
        };
        return new Samurai(unitData);
    }
    
}