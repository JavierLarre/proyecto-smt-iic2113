﻿using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Fighters;

namespace Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

public class TargetMenu: AbstractFighterTargetMenu
{
    
    public TargetMenu(IFighterModel attacker, IEnumerable<IFighterModel> targets)
    {
        SetTargets(targets.ToList());
        foreach (IFighterModel target in GetTargets())
        {
            IFighterView targetView = FighterViewFactory.FromFighter(target);
            AddOption(targetView.GetName(), targetView.GetInfo());
        }
        AddCancelOption();
        SetHeader($"Seleccione un objetivo para {attacker.GetState().Name}");
    }

    protected override string GetSeparator() => "-";
}