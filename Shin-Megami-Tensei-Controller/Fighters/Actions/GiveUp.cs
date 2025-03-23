using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class GiveUp: IAction
{
    public string ActionName() => "Rendirse";

    public bool IsDone() => true;

    public void Act(Table table, BattleFrontend frontend)
    {
        Fighter fighter = table.NextFighterInOrder();
        Team loser = table.GetTeamFromFighter(fighter);
        loser.Clear();
        int player = table.GetPlayerFromTeam(loser);
        frontend.WriteLine($"{loser.Samurai.Name} (J{player+1}) se rinde");
    }

    public void Reset()
    {
    }
}