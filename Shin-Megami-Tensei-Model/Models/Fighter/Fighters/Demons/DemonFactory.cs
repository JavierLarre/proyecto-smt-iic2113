namespace Shin_Megami_Tensei_Model;

public class DemonFactory: AbstractFighterFactory
{
    private const string JsonFile = "monsters.json";

    private static readonly IList<DemonDataFromJson> Data = GetData();

    private static IList<DemonDataFromJson> GetData()
    {
        return JsonDeserializer.Deserialize<DemonDataFromJson>(JsonFile);
    }

    private int GetDataIndex(DemonDataFromJson data)
    {
        return Data.IndexOf(data);
    }
    
    private DemonDataFromJson FindDataByName(string name) =>
        Data.First(demon => demon.name == name);

    public IFighter FromName(string name)
    {
        // if (name == "Jack Frost")
        // {
        //     Console.WriteLine("Hee Hoo");
        // }
        DemonDataFromJson demonData = FindDataByName(name);
        return BuildDemon(demonData);
    }

    public IEnumerable<IFighter> GetDemonLibrary()
    {
        return Data.Select(BuildDemon);
    }

    private Demon BuildDemon(DemonDataFromJson data)
    {
        UnitData unitData = new UnitData()
        {
            Affinities = BuildAffinitiesFrom(data.affinity),
            Stats = BuildStatsFrom(data.stats),
            Name = data.name,
            Skills = GetSkillsFromNames(data.skills),
            FightOptions = Demon.FightOptions,
            FilePriority = GetDataIndex(data)
        };
        return new Demon(unitData);
    }
}