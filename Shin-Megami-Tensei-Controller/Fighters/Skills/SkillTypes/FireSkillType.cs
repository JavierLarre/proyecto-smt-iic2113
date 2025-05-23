﻿using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Skills.SkillTypes;

public class FireSkillType: OffensiveMagicSkill
{
    protected override string GetMadeAction()
    {
        return "lanza fuego a";
    }

    protected override string GetAffinityString(IFighterModel target)
    {
        return target.GetUnitData().Affinities.Fire;
    }
}