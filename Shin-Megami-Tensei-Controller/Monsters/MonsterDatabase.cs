using Shin_Megami_Tensei.Common;

namespace Shin_Megami_Tensei.Monsters;

public static class MonsterDatabase
{
    private static string JsonFile = "monsters.json";
    private static List<MonsterData> MonsterDatas = [];

    private static void GetList()
    {
        if (MonsterDatas.Count == 0)
        {
            MonsterDatas = JsonParser.DeserializeList<MonsterData>(JsonFile);
        }
    }

    public static MonsterData Find(string monsterName){
        GetList();
        return MonsterDatas.First(monster => monster.name == monsterName);
    }
}