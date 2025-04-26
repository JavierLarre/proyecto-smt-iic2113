using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

public abstract class AbstractFighterView: IFighterView
{
    protected readonly IFighter Fighter;
    protected AbstractFighterView(IFighter fighter) => Fighter = fighter;
    public IFighter GetFighter() => Fighter;

    public string GetName() => Fighter.GetName();

    public string GetStats()
    {
        Stats stats = Fighter.GetStats();
        return $"HP:{stats.HpLeft}/{stats.MaxHp} MP:{stats.MpLeft}/{stats.MaxMp}";
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
        Stats stats = Fighter.GetStats();
        return $"{GetName()} termina con HP:{stats.HpLeft}/{stats.MaxHp}";
    }
}