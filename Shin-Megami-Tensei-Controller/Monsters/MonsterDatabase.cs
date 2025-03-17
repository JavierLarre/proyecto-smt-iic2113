using Shin_Megami_Tensei.Common;

namespace Shin_Megami_Tensei.Monsters;

public static class MonsterDatabase
{
    private const string JsonFile = "monsters.json";

    private static List<MonsterDataFromJson> DataList => 
        JsonDeserializer.DeserializeList<MonsterDataFromJson>(JsonFile);

    public static MonsterDataFromJson Find(string monsterName)
    {
        return DataList.First(monster => monster.name == monsterName);
    }
}