using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

public class SkillsView
{
    public ICollection<Skill> Skills;

    public SkillsView(ICollection<Skill> skills) => Skills = skills;

    public IEnumerable<string> GetSkillsInfo()
    {
        return Skills.Select(GetSkillInfo);
    }

    public IEnumerable<string> GetSkillsNames()
    {
        return Skills.Select(skill => skill.Name);
    }

    public static string GetSkillInfo(Skill skill) => $"{skill.Name} MP:{skill.Cost}";

}