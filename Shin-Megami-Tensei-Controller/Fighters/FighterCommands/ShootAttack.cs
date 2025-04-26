using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views.ConsoleView.Battle;
using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class ShootAttack: AttackCommand
{

    protected override int Modifier() => 80;
    protected override int FighterStat() => GetAttacker().GetStats().Skl;
    protected override string GetAttackString(IFighter reciever)
    {
        return 
            $"{GetAttacker().GetName()} dispara a {reciever.GetName()}";
    }

    protected override string GetAffinityString(IFighter target)
    {
        return target.GetAffinities().Gun;
    }
}