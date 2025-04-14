using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Battles;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class GiveUp: IAction
{
    public string ActionName() => "Rendirse";

    public bool IsDone() => true;

    public void Act(Table table, BattleView view)
    {
        Player loser = table.CurrentPlayer;
        throw new GameException($"{loser.Team.GetLeader().Name} (J{loser.PlayerNumber+1}) se rinde");
    }

    public void Reset()
    {
    }
}