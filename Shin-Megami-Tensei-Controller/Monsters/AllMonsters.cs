using Shin_Megami_Tensei;

namespace Shin_Megami_Tensei.Monsters;

public class AllMonsters
{
    private Monster[] Monsters = [];
    private List<MonsterInfo> MonsterInfos = [];

    public AllMonsters()
    {
        GetInfo();
        CopyMonsterInfoList();
    }

    private void GetInfo()
    {
        string jsonFile = "monsters.json";
        MonsterInfos = JsonParser.DeserializeList<MonsterInfo>(jsonFile);
    }
    
    private void CopyMonsterInfoList()
    {
        Monsters = new Monster[MonsterInfos.Count];
        for (int i = 0; i < MonsterInfos.Count; i++)
        {
            Monsters[i] = Monster.FromInfo(MonsterInfos[i]);
        }
    }
}