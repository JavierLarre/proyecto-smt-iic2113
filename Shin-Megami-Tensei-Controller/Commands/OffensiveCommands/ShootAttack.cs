using Shin_Megami_Tensei_Model;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class ShootAttack: OffensiveAttack
{

    protected override string GetAttackType() => "Gun";

    protected override int GetModifier() => 80;
    protected override int GetStat(Stats stats) => stats.Skl;

    protected override string GetAffinityString(Affinities affinities) => affinities.Gun;
}