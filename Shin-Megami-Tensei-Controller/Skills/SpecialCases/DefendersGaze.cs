using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Fighters.Skills;

namespace Shin_Megami_Tensei.Skills.SpecialCases;

public class DefendersGaze: ISkillController
{
    private SkillData _skillData;

    public DefendersGaze(SkillData skillData)
    {
        _skillData = skillData;
    }
    public void UseSkill(Table table)
    {
        GameState gameState = table.GetGameState();
        ConsumeAndGainTurns(gameState.TurnsModel);
        ConsumeMp(gameState.CurrentFighter);
    }

    private void ConsumeMp(IFighterModel currentFighter)
    {
        int oldMp = currentFighter.GetState().CurrentMp;
        int newMp = oldMp - _skillData.Cost;
        currentFighter.SetMp(newMp);
    }

    private static void ConsumeAndGainTurns(TurnsModel turnsModel)
    {
        const int gainedTurns = 3;
        turnsModel.ConsumeTurn();
        turnsModel.GainTurns(gainedTurns);
    }
}