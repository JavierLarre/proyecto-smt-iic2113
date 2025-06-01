using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Fighters;
using Shin_Megami_Tensei_View.Views;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Fighters.Skills;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class UseSkill: IFighterCommand, IViewController
{
    private Table _table = null!;
    private IFighterModel _caster = new EmptyFighter();

    public void Execute(Table table)
    {
        _table = table;
        _caster = table.GetGameState().CurrentFighter;
        IViewInput skillMenu = new SkillMenu(_caster);
        skillMenu.SetInput(this);
        try
        {
            skillMenu.Display();
        }
        catch (OptionException e)
        {
            throw new FighterCommandException();
        }
    }

    public void OnInput(string input)
    {
        SkillData choice = _caster.GetState().Skills
            .First(skill => skill.Name == input);
        ISkillController controller = SkillControllerFactory.FromData(choice);
        controller.UseSkill(_table);
    }
}