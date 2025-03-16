namespace Shin_Megami_Tensei.Samurais;

public class AllSamurai
{
    private Samurai[] Samurais = [];
    private List<SamuraiInfo> SamuraiInfos = [];

    public AllSamurai()
    {
        GetInfo();
        CopySamuraiInfoList();
    }

    private void GetInfo()
    {
        string jsonFile = "samurai.json";
        SamuraiInfos = JsonParser.DeserializeList<SamuraiInfo>(jsonFile);
    }

    private void CopySamuraiInfoList()
    {
        Samurais = new Samurai[SamuraiInfos.Count];
        for (int i = 0; i < SamuraiInfos.Count; i++)
        {
            Samurais[i] = Samurai.FromInfo(SamuraiInfos[i]);
        }
    }
}