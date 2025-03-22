using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Fighters.Actions;

public abstract class PhysAttack: IAction
{
    private bool _isDone = false;
    private const double PhysicalDamageMultiplier = 0.0114;

    protected abstract int Modifier();
    protected abstract int FighterStat();
    public abstract override string ToString();
    public bool IsDone() => _isDone;
    protected abstract void PrintAttack(BattleFrontend frontend, Fighter reciever);
    protected int CalculateDamage() =>
        (int)Math.Floor(FighterStat() * Modifier() * PhysicalDamageMultiplier);
    
    public void End() => _isDone = false;

    public void Act(Table table, Fighter fighter, BattleFrontend frontend)
    {
        Fighter? target = frontend.ChooseTargetFromUser(fighter);
        if (target is null) return;
        int damage = CalculateDamage();
        target.RecieveDamage(damage);
        PrintAttack(frontend, target);
        _isDone = true;
    }
}