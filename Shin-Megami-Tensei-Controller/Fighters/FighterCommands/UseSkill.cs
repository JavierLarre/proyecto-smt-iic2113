using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Fighters.Skills;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class UseSkill: IFighterCommand
{
    private IFighterModel _fighter = Table.GetInstance().GetCurrentFighter();

    public void Execute()
    {
        string skillName = GetSkillNameFromUser();
        SkillData choice = _fighter.GetUnitData().Skills
            .First(skill => skill.Name == skillName);
        ISkillController controller = SkillControllerFactory.BuildFromData(choice);
        controller.UseSkill();
    }

    private string GetSkillNameFromUser()
    {
        try
        {
            IOptionMenu skillMenu = new SkillMenu(_fighter);
            string skillName = skillMenu.GetChoice();
            return skillName;
        }
        catch (OptionException e)
        {
            throw new FighterCommandException();
        }
    }
}