using Shin_Megami_Tensei.Common;

namespace Shin_Megami_Tensei.Samurais;

public class SamuraiDatabase
{
    private static string JsonFile = "samurai.json";
    private static List<SamuraiData> SamuraiDatas = [];

    private static void GetList()
    {
        if (SamuraiDatas.Count == 0)
        {
            SamuraiDatas = JsonParser.DeserializeList<SamuraiData>(JsonFile);
        }
    }
    
    public static SamuraiData Find(string samuraiName){
        GetList();
        return SamuraiDatas.First(samurai => samurai.name == samuraiName);
    }

    private SamuraiDatabase()
    {
    }
}