namespace Shin_Megami_Tensei_Model;

public class DemonFactory: AbstractFighterFactory
{
    private const string JsonFile = "monsters.json";

    private readonly ICollection<DemonDataFromJson> _data = GetData();

    private static ICollection<DemonDataFromJson> GetData()
    {
        return JsonDeserializer.Deserialize<DemonDataFromJson>(JsonFile);
    }
    
    private DemonDataFromJson FindDataByName(string name) =>
        _data.First(demon => demon.name == name);

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
        return GetData().Select(BuildDemon);
    }

    private Demon BuildDemon(DemonDataFromJson data)
    {
        return new Demon(
            name: data.name,
            skills: GetSkillsFromNames(data.skills),
            stats: BuildStats(data.stats),
            affinities: BuildAffinities(data.affinity)
        );
    }
}