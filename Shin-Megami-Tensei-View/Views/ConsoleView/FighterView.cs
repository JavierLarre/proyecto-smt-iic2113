using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_Model.Fighters;
using Shin_Megami_Tensei_Model.Models.Fighter;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

public class FighterView
{
    private FighterState _state;

    public FighterView(IFighterModel fighter)
    {
        _state = fighter.GetState();
    }

    public string GetName() => _state.Name;

    public string GetStats()
    {
        if (_state.Name is null)
            return "";
        return $"{GetHpStats()} {GetMpStats()}";
    }

    public string GetInfo()
    {
        if (_state.Name is null)
            return "";
        return $"{GetName()} {GetStats()}";
    }

    public string GetHpEndedWith()
    {
        if (_state.Name is null)
            return "";
        return $"{GetName()} termina con {GetHpStats()}";
    }

    private string GetHpStats()
    {
        if (_state.Name == "")
            return "";
        return $"HP:{_state.CurrentHp}/{_state.MaxHp}";
    }

    private string GetMpStats()
    {
        if (_state.Name == "")
            return "";
        return $"MP:{_state.CurrentMp}/{_state.MaxMp}";
    }
}