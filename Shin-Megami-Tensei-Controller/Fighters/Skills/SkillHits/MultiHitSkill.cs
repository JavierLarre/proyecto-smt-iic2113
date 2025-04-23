using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillHits;

public class MultiHitSkill: ISkillHits
{
    private int _lowerBound;
    private int _upperBound;

    public MultiHitSkill(int lowerBound, int upperBound)
    {
        _lowerBound = lowerBound;
        _upperBound = upperBound;
    }
    public int CalculateHits()
    {
        int amountSkillsUsed = GetAmountSkillsUsed();
        int offset = GetOffset(amountSkillsUsed);
        return _lowerBound + offset;
    }

    private int GetOffset(int amountSkillsUsed)
    {
        return amountSkillsUsed % (_upperBound - _lowerBound + 1);
    }

    private static int GetAmountSkillsUsed()
    {
        Table table = Table.GetInstance();
        int amountSkillsUsed = table.GetCurrentPlayerUsedSkillsCount();
        return amountSkillsUsed;
    }
}