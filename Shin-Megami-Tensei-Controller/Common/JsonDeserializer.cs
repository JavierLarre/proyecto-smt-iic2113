using System.Text.Json;

namespace Shin_Megami_Tensei.Common;

public static class JsonDeserializer
{
    public static List<T> DeserializeList<T>(string fileName)
    {
        string jsonFolder = "data";
        string path = Path.Combine(jsonFolder, fileName);
        string json = File.ReadAllText(path);
        var dataList = JsonSerializer.Deserialize<List<T>>(json);
        if (dataList == null)
            throw new FileLoadException();
        
        return dataList;
    }
}