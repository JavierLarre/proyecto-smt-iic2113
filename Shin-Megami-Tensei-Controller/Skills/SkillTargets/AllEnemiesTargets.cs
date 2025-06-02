using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public class AllEnemiesTargets: ISkillTargets
{
    public ICollection<IFighterModel> GetTargets(Table table)
    {
        TeamState enemyTeam = table.GetGameState().EnemyPlayerState.TeamState;
        return enemyTeam
            .AliveTargets
            .Concat(enemyTeam.AliveReserve)
            .ToList();
    }
}