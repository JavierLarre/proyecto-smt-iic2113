using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class PhysAttack: AttackCommand
{
    protected override int Modifier() => 54;
    protected override int FighterStat() => GetAttacker().GetStats().Str;
    protected override string GetAttackString(IFighter reciever)
    {
        return $"{GetAttacker().GetName()} ataca a {reciever.GetName()}";
    }

    protected override string GetAffinityString(IFighter target)
    {
        return target.GetAffinities().Phys;
    }
}