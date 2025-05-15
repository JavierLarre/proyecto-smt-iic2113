using System.Text.RegularExpressions;
using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillHits;

public static class SkillHitFactory
{
    private static Regex _singleHitPattern = new(@"^(?<hits>\d+)$");
    private static Regex _multiHitPattern = new(@"^(?<lowerBound>\d+)-(?<upperBound>\d+)$");
    public static ISkillHits GetSkillHits(Skill skill)
    {
        string hit = skill.Hits;
        Match singleHitMatch = _singleHitPattern.Match(hit);
        Match multiHitMatch = _multiHitPattern.Match(hit);
        if (singleHitMatch.Success)
            return new SingleHitSkill();
        if (multiHitMatch.Success)
            return ParseMatch(multiHitMatch);
        
        throw new ArgumentException(hit);
    }

    private static MultiHitSkill ParseMatch(Match multiHitMatch)
    {
        string lowerBoundString = multiHitMatch.Groups["lowerBound"].Value;
        string upperBoundString = multiHitMatch.Groups["upperBound"].Value;
        int lowerBound = int.Parse(lowerBoundString);
        int upperBound = int.Parse(upperBoundString);
        return new MultiHitSkill(lowerBound, upperBound);
    }
    
}