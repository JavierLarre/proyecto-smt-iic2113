﻿using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters;

public interface IAffinityController
{
    public void RecieveAttack(IFighterModel target, double damage);
    public void ConsumeTurns();
    public string GetEffectString(IFighterModel target, double damage);
    //todo mover a vista
}