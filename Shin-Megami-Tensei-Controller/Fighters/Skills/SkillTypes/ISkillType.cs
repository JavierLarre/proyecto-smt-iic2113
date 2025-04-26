using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public interface ISkillType
{
    public void ApplyEffect(IFighter target, int power);
    public IAffinityController GetTargetAffinity(IFighter target);

    public string ToString(IFighter target, int power);
}