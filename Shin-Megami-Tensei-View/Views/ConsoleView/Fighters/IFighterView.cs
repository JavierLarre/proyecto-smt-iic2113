using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

public interface IFighterView
{
    public IFighter GetFighter();
    public string GetName();
    public string GetStats();
    public string GetInfo();
    public IEnumerable<string> GetOptions();
    public SkillsView GetSkills();
}