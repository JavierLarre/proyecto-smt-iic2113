using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Fighters.Actions;
using Shin_Megami_Tensei.Fighters.Skills;

namespace Shin_Megami_Tensei.Skills.SpecialCases;

public class Trafuri: ISkillController
{
    public void UseSkill(Table table)
    {
        new GiveUp().Execute(table);
    }
}