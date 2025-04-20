using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class UseSkill: IFighterCommand
{
    private IFighter _fighter;

    public UseSkill(IFighter fighter)
    {
        _fighter = fighter;
    }

    public void Execute(Table table, BattleView view)
    {
        try
        {
            IOptionMenu skillMenu = new SkillMenu(_fighter);
            string skillName = view.GetChoiceFromOptionMenu(skillMenu);

        }
        catch (OptionException e)
        {
            throw new FighterCommandException();
        }
    }
}