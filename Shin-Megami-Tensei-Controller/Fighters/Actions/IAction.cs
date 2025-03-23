using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Fighters.Actions;

public interface IAction
{
    public string ActionName();
    public bool IsDone();
    public void Act(Table table, BattleFrontend frontend);
    public void Reset();
}