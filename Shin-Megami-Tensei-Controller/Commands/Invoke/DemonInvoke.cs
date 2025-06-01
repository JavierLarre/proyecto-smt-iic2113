using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class DemonInvoke: AbstractInvoke
{
    protected override int GetSummonPosition()
    {
        Table table = Table.GetInstance();
        IFighterModel currentDemon = table.GetCurrentFighter();
        int atPosition = table.GetCurrentPlayer().GetTeam()
            .GetFrontRow().ToList().IndexOf(currentDemon);
        return atPosition;
    }
}