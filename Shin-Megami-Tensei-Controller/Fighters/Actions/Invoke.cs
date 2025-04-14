using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class Invoke: IAction 
{
    public string ActionName() => "Invocar";
    public bool IsDone() => true;
    public void Act(Table table, BattleView view)
    {
    }

    public void Reset()
    {
    }
}