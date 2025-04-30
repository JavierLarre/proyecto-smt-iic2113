using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

public abstract class AbstractFighterView: IFighterView
{
    protected readonly IFighter Fighter;
    protected AbstractFighterView(IFighter fighter) => Fighter = fighter;
    public IFighter GetFighter() => Fighter;

    public string GetName() => Fighter.GetUnitData().Name;

    public string GetStats()
    {
        Stats stats = Fighter.GetUnitData().Stats;
        return $"HP:{Fighter.GetCurrentHp()}/{stats.Hp} MP:{Fighter.GetCurrentMp()}/{stats.Mp}";
    }

    public IOptionMenu GetActionsMenu()
    {
        return new ActionMenu(Fighter);
    }

    public string GetInfo()
    {
        return $"{GetName()} {GetStats()}";
    }

    public string GetHpEndedWith()
    {
        Stats stats = Fighter.GetUnitData().Stats;
        return $"{GetName()} termina con HP:{Fighter.GetCurrentHp()}/{stats.Hp}";
    }
}