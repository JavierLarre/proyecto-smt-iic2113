using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class PhysAttack: AttackCommand
{
    protected override int Modifier() => 54;
    protected override int FighterStat() => GetAttacker().GetUnitData().Stats.Str;
    protected override string GetAttackString(IFighter reciever)
    {
        return $"{GetAttacker().GetUnitData().Name} ataca a {reciever.GetUnitData().Name}";
    }

    protected override string GetAffinityString(IFighter target)
    {
        return target.GetUnitData().Affinities.Phys;
    }
}