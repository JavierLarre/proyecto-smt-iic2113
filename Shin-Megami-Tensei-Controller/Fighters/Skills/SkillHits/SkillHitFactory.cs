namespace Shin_Megami_Tensei.Fighters.Skills.SkillHits;

public static class SkillHitFactory
{
    public static ISkillHits GetSkillHits(string hit)
    {
        return IsSingleHit(hit) ? new SingleHitSkill() : new MultiHitSkill();
    }

    private static bool IsSingleHit(string hit) => hit == "1";
    
}