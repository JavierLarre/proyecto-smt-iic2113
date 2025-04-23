using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Fighters.Skills;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class UseSkill: IFighterCommand
{
    private IFighter _fighter = Table.GetInstance().GetCurrentFighter();

    public void Execute()
    {
        string skillName = GetSkillNameFromUser();
        Skill choice = _fighter.GetSkillFromName(skillName);
        SkillController controller = SkillControllerBuilder.FromSkill(choice);
        controller.UseSkill();
    }

    private string GetSkillNameFromUser()
    {
        BattleView view = BattleViewSingleton.GetBattleView();
        try
        {
            IOptionMenu skillMenu = new SkillMenu(_fighter);
            string skillName = view.GetChoiceFromOptionMenu(skillMenu);
            return skillName;

        }
        catch (OptionException e)
        {
            throw new FighterCommandException();
        }
    }
}