using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class PhysAttack: OffensiveAttack
{
    public PhysAttack(Table table) : base(table)
    {
    }

    protected override string GetAttackType() => "Phys";

    protected override int GetModifier() => 54;
    protected override int GetStat(Stats stats) => stats.Str;
    protected override string GetAffinityString(Affinities affinities) => affinities.Phys;
}