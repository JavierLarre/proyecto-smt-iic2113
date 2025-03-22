using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Fighters.Actions;

public interface IAction
{
    public string ToString();
    public bool IsDone();
    public void Act(Table table, Fighter fighter, BattleFrontend frontend);
    public void End();
}