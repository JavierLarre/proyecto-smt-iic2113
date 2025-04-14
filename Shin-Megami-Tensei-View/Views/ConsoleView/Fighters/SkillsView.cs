using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

public class SkillsView
{
    private ICollection<Skill> _skills;

    public SkillsView(ICollection<Skill> skills) => _skills = skills;

    public IEnumerable<string> ViewSkills()
    {
        return _skills.Select(ViewSkill);
    }

    private string ViewSkill(Skill skill) => $"{skill.Name} MP:{skill.Cost}";
}