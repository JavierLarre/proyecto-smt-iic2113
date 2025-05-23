﻿using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class IceSkillType: OffensiveMagicSkill
{
    protected override string GetMadeAction()
    {
        return "lanza hielo a";
    }

    protected override string GetAffinityString(IFighterModel target)
    {
        return target.GetUnitData().Affinities.Ice;
    }
}