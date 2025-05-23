﻿using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class ElecSkillType: OffensiveMagicSkill
{
    protected override string GetMadeAction()
    {
        return "lanza electricidad a";
    }

    protected override string GetAffinityString(IFighterModel target)
    {
        return target.GetUnitData().Affinities.Elec;
    }
}