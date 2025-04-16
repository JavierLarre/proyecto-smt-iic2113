using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

public abstract class AbstractFighterView: IFighterView
{
    protected readonly IFighter Fighter;
    protected AbstractFighterView(IFighter fighter) => Fighter = fighter;
    public IFighter GetFighter() => Fighter;

    public string GetName() => Fighter.Name;

    public string GetStats()
    {
        Stats stats = Fighter.Stats;
        return $"HP:{stats.HpLeft}/{stats.MaxHp} MP:{stats.MpLeft}/{stats.MaxMp}";
    }

    public IEnumerable<string> GetOptions()
    {
        return Fighter.FightOptions;
    }

    public virtual string GetInfo()
    {
        return $"{GetName()} {GetStats()}";
    }

    public SkillsView GetSkills()
    {
        return new SkillsView(Fighter.GetSkills());
    }
}