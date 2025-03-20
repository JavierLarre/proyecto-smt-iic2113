using Shin_Megami_Tensei.Fighters.DataClassesForJson;

namespace Shin_Megami_Tensei.Fighters.Monsters;

public static class MonsterFactory
{
    private const string JsonFile = "monsters.json";

    private static readonly List<MonsterDataFromJson> DataList = 
        JsonDeserializer.DeserializeList<MonsterDataFromJson>(JsonFile);

    private static MonsterDataFromJson FindByName(string monsterName) =>
        DataList.First(monster => monster.name == monsterName);
    

    public static Monster FromName(string name)
    {
        // if(name == "Jack Frost")
        //     Console.WriteLine("HeeHoo");
        MonsterDataFromJson data = FindByName(name);
        return new Monster(data);
    }
}