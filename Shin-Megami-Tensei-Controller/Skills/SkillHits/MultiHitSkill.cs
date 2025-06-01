using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillHits;

public class MultiHitSkill: ISkillHits
{
    private int _lowerBound;
    private int _upperBound;
    private int _cachedHits = -1;

    public MultiHitSkill(int lowerBound, int upperBound)
    {
        _lowerBound = lowerBound;
        _upperBound = upperBound;
    }
    public int GetHits(Table table)
    {
        if (_cachedHits != -1)
            return _cachedHits;
        int amountSkillsUsed = GetAmountSkillsUsed(table);
        int offset = GetOffset(amountSkillsUsed);
        _cachedHits = _lowerBound + offset;
        return _cachedHits;
    }

    private int GetOffset(int amountSkillsUsed)
    {
        return amountSkillsUsed % (_upperBound - _lowerBound + 1);
    }

    private static int GetAmountSkillsUsed(Table table)
    {
        int amountSkillsUsed = table.GetGameState()
            .CurrentPlayerState
            .UsedSkills;
        return amountSkillsUsed;
    }
}