using System.Text.RegularExpressions;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillHits;

public static class SkillHitFactory
{
    private static Regex _singleHitPattern = new(@"(?<hits>\d+)");
    private static Regex _multiHitPattern = new(@"(?<lowerBound>\d+)-(?<upperBound>\d+)");
    public static ISkillHits GetSkillHits(string hit)
    {
        Match singleHitMatch = _singleHitPattern.Match(hit);
        if (singleHitMatch.Success)
            return new SingleHitSkill();
        Match multiHitMatch = _multiHitPattern.Match(hit);
        if (multiHitMatch.Success)
        {
            int lowerBound = int.Parse(multiHitMatch.Groups["lowerBound"].Value);
            int upperBound = int.Parse(multiHitMatch.Groups["upperBound"].Value);
            return new MultiHitSkill(lowerBound, upperBound);
        }
        throw new ArgumentException(hit);
    }

    private static bool IsSingleHit(string hit) => hit == "1";
    
}