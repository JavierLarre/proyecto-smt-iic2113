﻿using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Fighters.Skills;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class UseSkill: IAction
{
    private bool _isDone = false;
    
    public override string ToString()
    {
        return "Usar Habilidad";
    }

    public bool IsDone() => _isDone;

    public void Act(Table table, Fighter fighter, BattleFrontend frontend)
    {
        Skill? skill = frontend.ChooseSkillFromUser(fighter);
        if (skill is null) return;
        //implementar para prox entrega
    }

    public void End() => _isDone = false;
}