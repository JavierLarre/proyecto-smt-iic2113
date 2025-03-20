using Shin_Megami_Tensei.Fighters.DataClassesForJson;

namespace Shin_Megami_Tensei.Fighters.Samurais;

public static class SamuraiFactory
{
    private const string JsonFile = "samurai.json";

    private static readonly List<SamuraiDataFromJson> DataList = 
        JsonDeserializer.DeserializeList<SamuraiDataFromJson>(JsonFile);
    
    private static SamuraiDataFromJson FindByName(string name) =>
        DataList.First(samurai => samurai.name == name);
    
    public static Samurai FromName(string name)
    {
        SamuraiDataFromJson data = FindByName(name);
        return new Samurai(data);
    }
}