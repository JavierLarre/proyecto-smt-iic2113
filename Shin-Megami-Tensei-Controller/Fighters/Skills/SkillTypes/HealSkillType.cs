using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class HealSkillType: SupportiveSkillType
{
    public override string ToString(IFighterModel target, int power)
    {
        double healAmount = CalculateHealAmount(target, power);
        int truncatedHealAmount = Convert.ToInt32(Math.Floor(healAmount));
        IFighterModel healer = Table.GetInstance().GetCurrentFighter();
        string heals = $"{healer.GetUnitData().Name} cura a {target.GetUnitData().Name}";
        string recieves = $"{target.GetUnitData().Name} recibe {truncatedHealAmount} de HP";
        return heals + '\n' + recieves;
    }

}