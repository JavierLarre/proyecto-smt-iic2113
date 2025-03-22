using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class Pass: IAction 
{
    public override string ToString()
    {
        return "Pasar Turno";
    }

    public bool IsDone() => true;

    public void Act(Table table, Fighter fighter, BattleFrontend frontend)
    {
    }

    public void End()
    {
    }
}