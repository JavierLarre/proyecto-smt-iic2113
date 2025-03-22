using Shin_Megami_Tensei.Battles;
using Shin_Megami_Tensei.Teams;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class Shoot(Fighter attacker): PhysAttack
{
    private readonly Fighter _attacker = attacker;
    private const int _modifier = 80;

    public override string ToString()
    {
        return "Disparar";
    }
    protected override int Modifier() => _modifier;
    protected override int FighterStat() => _attacker.Stats.Skl;
    protected override void PrintAttack(BattleFrontend frontend, Fighter reciever)
    {
        frontend.WriteLines([
            $"{_attacker.Name} dispara a {reciever.Name}",
            $"{reciever.Name} recibe {CalculateDamage()} de daño",
            $"{reciever.Name} termina con {reciever.Stats.PrintHp()}"
        ]);
    }
}