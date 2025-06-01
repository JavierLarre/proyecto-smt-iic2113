using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTargets;

public class PartyTargets: ISkillTargets
{
    public ICollection<IFighterModel> GetTargets(Table table)
    {
        GameState gameState = table.GetGameState();
        return gameState.CurrentPlayerState.TeamState.FrontRow;
    }
}