using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class Invoke: IAction 
{
    public override string ToString()
    {
        return "Invocar";
    }
    
    public bool IsDone() => true;

    public void Act(Table table, Fighter fighter, BattleFrontend frontend)
    {
    }

    public void End()
    {
    }
}