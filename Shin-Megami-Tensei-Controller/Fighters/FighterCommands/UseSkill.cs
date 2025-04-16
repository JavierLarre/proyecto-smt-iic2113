using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class UseSkill: IFighterCommand
{
    private Table _table;
    private BattleView _view;

    public UseSkill(Table table, BattleView view)
    {
        _table = table;
        _view = view;
    }

    public void Execute()
    {
        string choice;
        try
        {
            choice = _view.GetSkillFromUser();
        }
        catch (OptionException e)
        {
            throw new FighterCommandException();
        }

        if (choice == "Cancelar")
            throw new FighterCommandException();
    }
}