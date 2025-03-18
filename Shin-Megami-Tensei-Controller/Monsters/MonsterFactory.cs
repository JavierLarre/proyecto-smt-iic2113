using Shin_Megami_Tensei.Common;

namespace Shin_Megami_Tensei.Monsters;

public static class MonsterFactory
{
    private const string JsonFile = "monsters.json";

    private static readonly List<MonsterDataFromJson> DataList = 
        JsonDeserializer.DeserializeList<MonsterDataFromJson>(JsonFile);

    private static MonsterDataFromJson FindByName(string monsterName) =>
        DataList.First(monster => monster.name == monsterName);
    

    public static Monster FromName(string name)
    {
        MonsterDataFromJson data = FindByName(name);
        return new Monster(data);
    }
}