using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

public abstract class AbstractFighterView: IFighterView
{
    protected readonly IFighter Fighter;

    protected AbstractFighterView(IFighter fighter)
    {
        Fighter = fighter;
    }

    public string GetFighterName() => Fighter.Name;

    public string GetFighterStats()
    {
        Stats stats = Fighter.Stats;
        return $"HP:{stats.HpLeft}/{stats.MaxHp} MP:{stats.MpLeft}/{stats.MaxMp}";
    }

    public virtual string GetFighterInfo()
    {
        return $"{GetFighterName()} {GetFighterStats()}";
    }
}