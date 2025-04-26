using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class ReviveSkillType: SupportiveSkillType
{
    public override string ToString(IFighter target, int power)
    {
        double healAmount = CalculateHealAmount(target, power);
        int truncatedHealAmount = Convert.ToInt32(Math.Floor(healAmount));
        IFighter healer = Table.GetInstance().GetCurrentFighter();
        string heals = $"{healer.GetName()} revive a {target.GetName()}";
        string recieves = $"{target.GetName()} recibe {truncatedHealAmount} de HP";
        return heals + '\n' + recieves;
    }
}