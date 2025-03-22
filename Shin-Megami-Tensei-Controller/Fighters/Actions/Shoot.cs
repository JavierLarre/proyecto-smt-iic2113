using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class Shoot: IAction
{
    private bool _isDone = false;
    public override string ToString()
    {
        return "Disparar";
    }

    public bool IsDone() => _isDone;
    
    public void Act(Table table, Fighter fighter, BattleFrontend frontend)
    {
        Fighter? target = frontend.ChooseTargetFromUser(fighter);
        if (target is null) return;
        int damage = CalculateDamage(fighter);
        target.RecieveDamage(damage);
        frontend.PrintShoot(fighter, target, damage);
        _isDone = true;
        table.CleanRows();
    }

    private int CalculateDamage(Fighter attacker)
    {
        int stat = attacker.Stats.Skl;
        const int modifier = 80;
        return (int)Math.Floor(stat * modifier * Constants.PhysicalDamageMultiplier);
    }

    public void End() => _isDone = false;
}