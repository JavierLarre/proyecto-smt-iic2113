namespace Shin_Megami_Tensei_Model;

public class SkillFactory
{
    private string _jsonFile = "skills.json";
    
    private ICollection<SkillDataFromJson> _dataList;

    public SkillFactory()
    {
        _dataList = JsonDeserializer.Deserialize<SkillDataFromJson>(_jsonFile);
    }

    private SkillDataFromJson FindByName(string skillName) =>
        _dataList.First(skill => skill.name == skillName);

    public SkillData FromName(string name)
    {
        var data = FindByName(name);
        return new SkillData
        {
            Cost = data.cost,
            Effect = data.effect,
            Hits = data.hits,
            Name = data.name,
            Power = data.power,
            Target = data.target,
            Type = data.type
        };
    }
}