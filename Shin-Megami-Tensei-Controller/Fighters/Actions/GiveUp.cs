using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class GiveUp: IAction 
{
    public override string ToString()
    {
        return "Rendirse";
    }

    public bool IsDone() => true;

    public void Act(Table table, Fighter fighter, BattleFrontend frontend)
    {
        Team loser = table.GetTeamFromFighter(fighter);
        loser.Clear();
        frontend.PrintGiveUp(fighter);
    }

    public void End()
    {
    }
}