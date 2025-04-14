using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Actions;

public interface IAction
{
    public string ActionName();
    public bool IsDone();
    public void Act(Table table, BattleView view);
    public void Reset();
}