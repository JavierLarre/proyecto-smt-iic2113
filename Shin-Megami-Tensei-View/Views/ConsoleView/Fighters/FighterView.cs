using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Models.Fighter;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

public class FighterView: IFighterView
{
    private FighterState _state;
    public FighterView(IFighterModel fighter)
    {
        _state = fighter.GetState();
    }

    public string GetName() => _state.Name;

    public string GetInfo()
    {
        return $"{GetName()} {GetStats()}";
    }

    public string GetStats()
    {
        return $"{GetHpStats()} {GetMpStats()}";
    }

    public string GetHpEndedWith()
    {
        return $"{GetName()} termina con {GetHpStats()}";
    }

    private string GetHpStats()
    {
        return $"HP:{_state.CurrentHp}/{_state.MaxHp}";
    }

    private string GetMpStats()
    {
        return $"MP:{_state.CurrentMp}/{_state.MaxMp}";
    }
}