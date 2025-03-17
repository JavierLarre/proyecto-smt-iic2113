using Shin_Megami_Tensei.Common;

namespace Shin_Megami_Tensei.Samurais;

public static class SamuraiDatabase
{
    private const string JsonFile = "samurai.json";

    private static List<SamuraiDataFromJson> DataList => 
        JsonDeserializer.DeserializeList<SamuraiDataFromJson>(JsonFile);
    
    public static SamuraiDataFromJson FindByName(string samuraiName)
    {
        return DataList.First(samurai => samurai.name == samuraiName);
    }
}