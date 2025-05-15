using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public interface ISkillType
{
    public void ApplyEffect(IFighterModel target, int power);
    public IAffinityController GetTargetAffinity(IFighterModel target);

    public string ToString(IFighterModel target, int power);
}