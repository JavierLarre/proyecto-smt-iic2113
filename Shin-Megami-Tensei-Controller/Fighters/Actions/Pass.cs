using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class Pass: IAction 
{
    public string ActionName() => "Pasar Turno";
    public bool IsDone() => true;
    public void Act(Table table, BattleFrontend frontend)
    {
    }
    public void Reset()
    {
    }
}