using System.Text.Json;

namespace Shin_Megami_Tensei.Common;

public class JsonParser
{
    public static List<T> DeserializeList<T>(string fileName)
    {
        string path = Path.Combine("data", "json", fileName);
        string json = File.ReadAllText(path);
        List<T> monsterList = JsonSerializer.Deserialize<List<T>>(json);
        if (monsterList == null)
        {
            throw new FileLoadException();
        }
        return monsterList;
    }
}