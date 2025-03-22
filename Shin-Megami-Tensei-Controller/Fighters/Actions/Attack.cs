using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class Attack: IAction
{
    private bool _isDone = false;
    public override string ToString()
    {
        return "Atacar";
    }

    public bool IsDone() => _isDone;

    public void Act(Table table, Fighter fighter, BattleFrontend frontend)
    {
        Fighter? target = frontend.ChooseTargetFromUser(fighter);
        if (target is null) return;
        int damage = CalculateDamage(fighter);
        target.RecieveDamage(damage);
        frontend.PrintAttack(fighter, target, damage);
        table.CleanRows();
        _isDone = true;
    }

    private int CalculateDamage(Fighter atacker)
    {
        int stat = atacker.Stats.Str;
        const int modifier = 54;
        return (int) Math.Floor(stat * modifier * Constants.PhysicalDamageMultiplier);
    }
    public void End() => _isDone = false;
}